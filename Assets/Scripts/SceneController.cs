using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameManager gm;
    public UIManager ui;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        gm = GameManager.instance;
        ui = UIManager.instance;

    }

    private void OnEnable()
    {
        ui.UIcg.alpha = 1;
    }

    private void OnDisable()
    {
        ui.UIcg.alpha = 0;
    }
}
