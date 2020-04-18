using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    public float maxHealth = 100f;

    public float health { get ; set ; }

    public void Damage(float damageTaken)
    {
        if (damageTaken > 0) health = Mathf.Clamp(health - damageTaken,0,maxHealth);
        if (health <= 0) Kill();
    }



    public void Heal(float damageHealed)
    {
        if(damageHealed>0) health = Mathf.Clamp(health + damageHealed,0,maxHealth);
    }

    public void Kill()
    {
       Debug.Log("The Player Was Killed, Not implemented");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
