using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOverManager : MonoBehaviour
{
    private GameManager gm;

    public Button introButton;
    public Button playButton;
    public Button settingsButton;
    public Button controlsButton;

    public Slider difficultySlider;
    public TMP_Text difficultyName;

    public TMP_Text gameOverFlavor;


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
        gm.isIntro = false;
        //introButton.onClick.AddListener(LoadIntro);
        //Debug.Log("Health = " + gm.playerHealth.ToString());
        //Debug.Log("Scene build index: " + SceneManager.GetActiveScene().buildIndex);
        gameOverFlavor.text = gm.gameOverReason;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadIntro()
    {
        gm.isIntro = true;
        Debug.Log("LoadIntro() called once from GameOverManager");
        gm.LoadScene((int)SceneIndices.GAME_OVER, (int)SceneIndices.INTRO);
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
        difficultySlider.value = GameManager.instance.difficulty;
        difficultyName.text = GameManager.instance.diffSettings[(int)difficultySlider.value].diffName;
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

    public void DifficultyChanged()
    {
        GameManager.instance.difficulty = (int)difficultySlider.value;
        difficultyName.text = GameManager.instance.diffSettings[(int)difficultySlider.value].diffName;
    }
}
