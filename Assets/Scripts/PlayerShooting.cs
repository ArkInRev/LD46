using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    //private GameManager gm;

    //public Rigidbody rb;
    public GameObject projectile;
    public Transform muzzleTip;

    private bool tryFire1;

    private void Awake()
    {
        //gm = GameManager.instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            tryFire1 = true;
        }

    }

    private void FixedUpdate()
    {
        if (tryFire1)
        {
            GameObject obj = Instantiate(projectile, muzzleTip.transform.position, muzzleTip.rotation);
            obj.transform.position = muzzleTip.position;
            tryFire1 = false;
        }
    }
}
