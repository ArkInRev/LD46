using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int playerHealth = 10;

    private void Awake()
    {
        instance = this;
        SceneManager.LoadSceneAsync((int)SceneIndices.TITLESCREEN, LoadSceneMode.Additive);    
    }


    public void LoadScene(int sceneToUnload, int sceneToLoad)
    {
        SceneManager.UnloadSceneAsync(sceneToUnload);
        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
    }

    

}
