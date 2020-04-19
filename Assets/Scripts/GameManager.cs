using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    
  

    [Header("GameSettings")]
    [SerializeField] private float playerHealth = 100;
    [SerializeField] private float playerShield = 100;
    [SerializeField] private float turretHealth = 50;
    [SerializeField] private float enemyHealth = 30;
    [SerializeField] private float larvaHealth = 100;
    [SerializeField] private float playerDamage = 10;
    [SerializeField] private float enemyDamage = 10;
    [SerializeField] private float startSeq = 50;
    [SerializeField] private float seqDecay = 1;
    [SerializeField] private float energyGain = 35;
    [SerializeField] private float healthGain = 35;
    [SerializeField] private float seqGain = 10;
    [SerializeField] private float eShootFreq = 1.5f;
    [SerializeField] private float tShootFreq = 1.5f;
    [SerializeField] private float hDropChance = .15f;
    [SerializeField] private float eDropChance = .5f;
    [SerializeField] private float sDropChance = .35f;


    [Header("Difficulty Settings")]
    public int difficulty = 1;
    [SerializeField] public DifficultySettings[] diffSettings;

    public GameObject larva;
    public LarvaController larvaC;
    public GameObject shield;
    public ShieldController shieldC;
    public GameObject player;
    public PlayerController playerC;

    public bool isIntro;
    public string gameOverReason;
    
    #region basics
    private void Awake()
    {
        instance = this;

        SceneManager.LoadSceneAsync((int)SceneIndices.TITLESCREEN, LoadSceneMode.Additive);
    }

    private void OnEnable()
    {
        //UIManager.instance.enabled = true;
    }

    #endregion
    public void LoadScene(int sceneToUnload, int sceneToLoad)
    {
        SceneManager.UnloadSceneAsync(sceneToUnload);
        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
    }

    #region Difficulty Management

    public float GetPlayerHealth() { return diffSettings[difficulty].pHealthMult * playerHealth; }
    public float GetPlayerShield() { return diffSettings[difficulty].pShieldMult * playerShield; }
    public float GetTurretHealth() { return diffSettings[difficulty].tHealthMult * turretHealth; }
    public float GetEnemyHealth() { return diffSettings[difficulty].eHealthMult * enemyHealth; }
    public float GetLarvaHealth() { return diffSettings[difficulty].lHealthMult * larvaHealth; }
    public float GetPlayerDamage() { return diffSettings[difficulty].pDamageMult * playerDamage; }
    public float GetEnemyDamage() { return diffSettings[difficulty].eDamageMult * enemyDamage; }
    public float GetStartSeq() { return diffSettings[difficulty].lStartSeqMult * startSeq; }
    public float GetSeqDecay() { return diffSettings[difficulty].lDecaySeqMult * seqDecay; }
    public float GetEnergyGain() { return diffSettings[difficulty].eGainMult * energyGain; }
    public float GetHealthGain() { return diffSettings[difficulty].hGainMult * healthGain; }
    public float GetSeqGain() { return diffSettings[difficulty].sGainMult * seqGain; }
    public float GetTurretShootFreq() { return diffSettings[difficulty].eShootFreqMult * tShootFreq; }
    public float GetEnemyShootFreq() { return diffSettings[difficulty].eShootFreqMult * eShootFreq; }
    public float GetHealthDropChance() { return diffSettings[difficulty].hDropMult * hDropChance; }
    public float GetEnergyDropChance() { return diffSettings[difficulty].eDropMult * eDropChance; }
    public float GetSeqDropChance() { return diffSettings[difficulty].sDropMult * sDropChance; }

    #endregion


    #region Events
    public void SetLarvaGameObject(GameObject go)
    {
        larva = go;
        larvaC = go.GetComponent<LarvaController>();
    }

    public void SetShieldGameObject(GameObject go)
    {
        shield = go;
        shieldC = go.GetComponent<ShieldController>();
    }

    public void SetPlayerGameObject(GameObject go)
    {
        player = go;
        playerC = go.GetComponent<PlayerController>();
    }

    public event Action onLarvaKilled;
    public void LarvaKilled()
    {
        gameOverReason = "You Failed to Protect the Spawn of the Infinite Void, Blessing from beyond, and ruin of the galaxy.";
        if (onLarvaKilled != null)
        {
            onLarvaKilled();
        }
        Debug.Log("Game Manager just saw the larva be killed.");
        //temp reload the scene for testing
        SceneManager.UnloadSceneAsync((int)SceneIndices.INTRO);
        SceneManager.LoadSceneAsync((int)SceneIndices.GAME_OVER,LoadSceneMode.Additive);
    }

    public event Action onLarvaHealthChange;
    public void LarvaHealthChange()
    {
        if(onLarvaHealthChange != null)
        {
            onLarvaHealthChange();
            
        }

    }

    public event Action onLarvaSeqChange;
    public void LarvaSeqChange()
    {
        if (onLarvaSeqChange != null)
        {
            onLarvaSeqChange();

        }

    }

    public event Action onSeqDepleted;
    public void SeqDepleted()
    {
        gameOverReason = "You did not feed the larva enough organic material to complete the genetic morph. The cult is disappointed with you.";
        if (onSeqDepleted != null)
        {
            onSeqDepleted();
        }

        //temp reload the scene for testing
        SceneManager.UnloadSceneAsync((int)SceneIndices.INTRO);
        SceneManager.LoadSceneAsync((int)SceneIndices.GAME_OVER, LoadSceneMode.Additive);
    }

    public event Action onShieldHealthChange;
    public void ShieldHealthChange()
    {
        if (onShieldHealthChange != null)
        {
            onShieldHealthChange();

        }

    }

    public event Action onPlayerKilled;
    public void PlayerKilled()
    {
        if (onPlayerKilled != null)
        {
            onPlayerKilled();

        }

    }

    public event Action onPlayerHealthChange;
    public void PlayerHealthChange()
    {
        if (onPlayerHealthChange != null)
        {
            onPlayerHealthChange();

        }

    }


    public event Action onDNAPickup;
    public void DNAPickup()
    {
        if (onDNAPickup != null)
        {
            onDNAPickup();

        }
        DNAChange();
    }

    public event Action onDNADeliver;
    public void DNADeliver()
    {
        if (onDNADeliver != null)
        {
            onDNADeliver();

        }
        DNAChange();
    }

    public event Action onDNAChange;
    public void DNAChange()
    {
        if (onDNAChange != null)
        {
            onDNAChange();

        }

    }
    #endregion

}
