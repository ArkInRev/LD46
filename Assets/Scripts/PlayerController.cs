using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IDamageable
{
    private GameManager gm;
    public float maxHealth = 100f;
    public GameObject shieldGO;

    public int seqCarried = 0;

    public float health { get ; set ; }

    public void Damage(float damageTaken)
    {
        if (damageTaken > 0) health = Mathf.Clamp(health - damageTaken,0,maxHealth);
        if (health <= 0) Kill();
        gm.PlayerHealthChange();
    }

    public void PickupDNA()
    {
        seqCarried += 1;
        gm.DNAPickup();
    }


    public void Heal(float damageHealed)
    {
        if(damageHealed>0) health = Mathf.Clamp(health + damageHealed,0,maxHealth);
        gm.PlayerHealthChange();
    }

    public void Kill()
    {

        //Debug.Log("The Player Was Killed, Not implemented");
        ResetSeqCarried();
        gm.DNAChange();
        gm.PlayerKilled();
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        gm.SetPlayerGameObject(this.gameObject);
        maxHealth = gm.GetPlayerHealth();
        health = gm.GetPlayerHealth();
        ResetSeqCarried();
    }

    private void Awake()
    {
        
    }

    void OnEnable()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;

       // health = maxHealth;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetSeqCarried()
    {
        seqCarried = 0;
        gm.DNAChange();
    }
}
