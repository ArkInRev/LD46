using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientHealthBar : MonoBehaviour
{
    //Camera cam;
    Quaternion rot;
    // Start is called before the first frame update
    void Start()
    {
        rot = Quaternion.identity;
        rot.eulerAngles = new Vector3(0, 0, 0)
;        //cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = rot  ;
    }
}
