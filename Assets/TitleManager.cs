﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleManager : MonoBehaviour
{
    private GameManager gm;

    public Button introButton;
    public Button playButton;
    public Button settingsButton;
    public Button controlsButton;


    public enum TitleWindows
    {
        TITLE = 0,
        SETTINGS = 1,
        CONTROLS = 2
    }

    public CanvasGroup[] titleCGs;

    public int lastTitleWindow;
    public int currentTitleWindow;

    private void Awake()
    {
        gm = GameManager.instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        //introButton.onClick.AddListener(LoadIntro);
        Debug.Log("Health = " + gm.playerHealth.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadIntro()
    {

        Debug.Log("LoadIntro() called once from TitleManager");
        gm.LoadScene((int)SceneIndices.TITLESCREEN, (int)SceneIndices.INTRO);
    }

    public void EnableCanvasGroup(int cg)
    {
        //temp
        titleCGs[cg].alpha = 1.0f;
        titleCGs[cg].interactable = true;
        titleCGs[cg].blocksRaycasts = true;
    }

    public void DisableCanvasGroup(int cg)
    {
        //temp
        titleCGs[cg].alpha = 0.0f;
        titleCGs[cg].interactable = false;
        titleCGs[cg].blocksRaycasts = false;
    }

    public void ClickSettings()
    {
        DisableCanvasGroup(currentTitleWindow);
        lastTitleWindow = currentTitleWindow;
        currentTitleWindow = (int)TitleWindows.SETTINGS;
        EnableCanvasGroup(currentTitleWindow);
    }

    public void ClickBack()
    {
        int lastWin = lastTitleWindow;
        DisableCanvasGroup(currentTitleWindow);
        lastTitleWindow = currentTitleWindow;
        currentTitleWindow = lastWin;
        EnableCanvasGroup(currentTitleWindow);
    }

    public void ClickControls()
    {
        DisableCanvasGroup(currentTitleWindow);
        lastTitleWindow = currentTitleWindow;
        currentTitleWindow = (int)TitleWindows.CONTROLS;
        EnableCanvasGroup(currentTitleWindow);
    }
}
