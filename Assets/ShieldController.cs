using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour,IDamageable
{
    private GameManager gm;

    public PlayerMovement pm;

    public float health { get ; set ; }
    public float maxHealth;
    public ParticleSystem shatterParticles;
    public GameObject shatteredShield;

    private void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        gm.SetShieldGameObject(this.gameObject);
        health = gm.GetPlayerShield();
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    public void Kill()
    {
        Instantiate(shatterParticles, this.transform.position, transform.rotation);
        Instantiate(shatteredShield, this.transform.position, transform.rotation);
        
    }

    public void Damage(float damageTaken)
    {
        if (damageTaken > 0) health = Mathf.Clamp(health - damageTaken, 0, maxHealth);
        //healthBar.fillAmount = health / maxHealth;
        // gm.LarvaHealthChange();
        //// observer for shield damage
        if (health <= 0) Kill();
        gm.ShieldHealthChange();
    }

    public void Heal(float damageHealed)
    {
        //throw new System.NotImplementedException();
        if (damageHealed > 0) health = Mathf.Clamp(health + damageHealed, 0, maxHealth);
        gm.ShieldHealthChange();
    }
}
