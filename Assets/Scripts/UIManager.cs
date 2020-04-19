using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Slider larvaHealthUI;
    public Slider larvaSeqUI;

    public CanvasGroup UIcg;

    private bool reloadUI = false;

    void Awake()
    {
        instance = this;

    }


    // Start is called before the first frame update
    void Start()
    {

        GameManager.instance.onLarvaHealthChange += OnLarvaHealthChange;
        larvaHealthUI.minValue = 0f;
        larvaHealthUI.maxValue = GameManager.instance.GetLarvaHealth();
        larvaHealthUI.value = larvaHealthUI.maxValue;
        GameManager.instance.onLarvaSeqChange += OnLarvaSeqChange;
    }

    private void OnLarvaHealthChange()
    {
        larvaHealthUI.minValue = 0f;
        larvaHealthUI.maxValue = GameManager.instance.larvaC.maxHealth;
        larvaHealthUI.value = GameManager.instance.larvaC.health;
        //Debug.Log("Larva health is " + GameManager.instance.larvaC.health.ToString() + " out of " + GameManager.instance.larvaC.maxHealth);
    }

    private void OnLarvaSeqChange()
    {
        larvaSeqUI.minValue = 0f;
        larvaSeqUI.maxValue = 100f;
        larvaSeqUI.value = GameManager.instance.larvaC.seq;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance != null)
        {
            if (reloadUI)
            {
                if (GameManager.instance.larvaC != null)
                {
                    OnLarvaHealthChange();
                    reloadUI = false;

                }
            }
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        reloadUI = true;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
