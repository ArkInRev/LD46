using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Enemy : MonoBehaviour, IDamageable
{
    private GameManager gm;
    public GameObject target;
    public GameObject player;
    public GameObject larva;

    public bool isPoweredOn = true;
    public float explodeRadius = 5f;
    public float explodeForce = 500f;
    public float shootFreq;

    public GameObject projectile;
    public Transform[] muzzleTip = new Transform[2];
    public float bulletForce = 20f;

    private float timeSinceLastShot = 0;

    public float rotSpeed = 1.25f;

    public float maxHealth;
    public float health { get; set; }

    public Image healthBar;
    public GameObject deadEnemyModel;
    public ParticleSystem explosionParticles;

    public float targetChange;
    private float timeSinceLastTargetChange;

    private int currentMuzzle = 0;

    public float sDropChance;
    public GameObject drop;

    public float lookRadius = 10f;
    NavMeshAgent agent;

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        player = GameObject.FindWithTag("Player");
        larva = GameObject.FindWithTag("Larva");
        target = GameObject.FindWithTag("Player");

        maxHealth = gm.GetEnemyHealth();
        health = gm.GetEnemyHealth();

        healthBar.fillAmount = 1;

        shootFreq = gm.GetEnemyShootFreq();
        sDropChance = gm.GetSeqDropChance();
        if (gm.isIntro) { sDropChance = 1f; }

        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
    }

    private void FixedUpdate()
    {
        if (isPoweredOn)
        {
            Vector3 targetPoint = target.transform.position;
            targetPoint.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
            timeSinceLastShot += Time.fixedDeltaTime;
            if (timeSinceLastShot > shootFreq)
            {
                Shoot(target.transform);
            }

            timeSinceLastTargetChange += Time.fixedDeltaTime;
            if (timeSinceLastTargetChange > targetChange)
            {
                int targetChoice = Random.Range((int)0, (int)2);
                if (targetChoice == 0) { target = player; } else { target = larva; }
                targetChange = Random.Range(5.0f, 10.0f);
            }




        }
    }

    public void Shoot(Transform target)
    {

        GameObject bullet = Instantiate(projectile, muzzleTip[(int)currentMuzzle].position, muzzleTip[(int)currentMuzzle].rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(muzzleTip[currentMuzzle].up * bulletForce, ForceMode.Impulse);
        currentMuzzle += 1;
        currentMuzzle %= muzzleTip.Length;
        timeSinceLastShot = 0;
    }

    public void Kill()
    {
        //Explode

        Instantiate(explosionParticles, this.transform.position, transform.rotation);
        Instantiate(deadEnemyModel, this.transform.position, transform.rotation);
        DropLoot();
        Collider[] colliders = Physics.OverlapSphere(transform.position, explodeRadius);
        foreach (Collider nearCollider in colliders)
        {
            Rigidbody rb = nearCollider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("Rigidbody found in explosion.");
                rb.AddExplosionForce(explodeForce, transform.position, explodeRadius);
            }
        }
        Die();

    }

    public void Damage(float damageTaken)
    {
        if (damageTaken > 0) health = Mathf.Clamp(health - damageTaken, 0, maxHealth);
        healthBar.fillAmount = health / maxHealth;
        // gm.LarvaHealthChange();
        if (health <= 0) Kill();
    }

    public void Heal(float damageHealed)
    {
        //turrets are not healing
        //throw new System.NotImplementedException();
    }

    public void Die()
    {
        Destroy(gameObject);
        return;
    }

    public void DropLoot()
    {
        float lootRoll = Random.Range(0f, 1f);
        Debug.Log("Loot roll was " + lootRoll + " looking for " + sDropChance);
        if (lootRoll <= sDropChance)
        {
            Debug.Log("Dropping Loot");
            Instantiate(drop, transform.position, Quaternion.identity);
        }
    }
}
