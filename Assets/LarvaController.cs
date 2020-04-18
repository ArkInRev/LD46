using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarvaController : MonoBehaviour, IDamageable
{
    private GameManager gm;

    public float maxHealth = 100f;

    public float health { get; set; }

    public void Damage(float damageTaken)
    {
        if (damageTaken > 0) health = Mathf.Clamp(health - damageTaken, 0, maxHealth);
        if (health <= 0) Kill();
    }



    public void Heal(float damageHealed)
    {
        if (damageHealed > 0) health = Mathf.Clamp(health + damageHealed, 0, maxHealth);
    }

    public void Kill()
    {
        gm.LarvaKilled();
        Debug.Log("The Larva has Died.");
        //throw new System.NotImplementedException("The Larva Was Killed, Not implemented");
    }

    void Awake()
    {
        gm = GameManager.instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        gm.onLarvaKilled += OnLarvaKilled;
    }

    private void OnLarvaKilled()
    {
        Debug.Log("LarvaControler OnLarvaKilled. ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        health = maxHealth;
    }
}
