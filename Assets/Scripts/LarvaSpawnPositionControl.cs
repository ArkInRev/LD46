using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarvaSpawnPositionControl : MonoBehaviour
{
    private GameObject larvaGO;

    // Start is called before the first frame update
    void Start()
    {
        larvaGO = GameObject.FindGameObjectWithTag("Larva");

        
        larvaGO.transform.position = this.transform.position;

        Destroy(this.gameObject);
    }
}