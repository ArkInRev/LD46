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


    [Header("Difficulty Settings")]
    public int difficulty = 1;
    [SerializeField] public DifficultySettings[] diffSettings;

    public GameObject larva;
    public LarvaController larvaC;


    
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


    #endregion


    #region Events
    public void SetLarvaGameObject(GameObject go)
    {
        larva = go;
        larvaC = go.GetComponent<LarvaController>();
    }
    
    public event Action onLarvaKilled;
    public void LarvaKilled()
    {
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


    #endregion

}
