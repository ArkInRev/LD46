using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LarvaController : MonoBehaviour, IDamageable
{
    private GameManager gm;

    public float maxHealth = 100f;

    public float health { get; set; }

    public float seq;
    public float seqMax = 100f;
    public float seqDecay;
 //   public float timesincelastdecay = 0;

    public void Damage(float damageTaken)
    {
        if (damageTaken > 0) health = Mathf.Clamp(health - damageTaken, 0, maxHealth);
        gm.LarvaHealthChange();
        if (health <= 0) Kill();
    }



    public void Heal(float damageHealed)
    {
        if (damageHealed > 0) health = Mathf.Clamp(health + damageHealed, 0, maxHealth);
        gm.LarvaHealthChange();
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
        gm.SetLarvaGameObject(this.gameObject);
        gm.onLarvaKilled += OnLarvaKilled;
        maxHealth = gm.GetLarvaHealth();
        health = gm.GetLarvaHealth();
        gm.LarvaHealthChange();

        seq = gm.GetStartSeq();
        seqDecay = gm.GetSeqDecay();

    }

    private void OnLarvaKilled()
    {
        Debug.Log("LarvaControler OnLarvaKilled. ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        seq -= (seqDecay * Time.fixedDeltaTime);
        gm.LarvaSeqChange();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;


    }

    void onDisable()
    {
        gm.onLarvaKilled -= OnLarvaKilled;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }
}
