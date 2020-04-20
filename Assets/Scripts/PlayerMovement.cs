using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameManager gm;

    public float moveSpeed = 5f;
    public float rotSpeed = 5f;

    public Rigidbody rb;
    public Camera cam;

    public GameObject projectile;
    public Transform muzzleTip;

    private bool tryFire1;
    public float bulletForce = 20f;

    private bool tryFire2;
    public bool usingShield = false;
    private float shieldHealth;
    public GameObject shield;
    public ShieldController shieldController;

    Vector3 moveDirection;
    private void Awake()
    {
        gm = GameManager.instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        moveDirection.y = 0;
        shieldHealth = gm.GetPlayerShield();
        shieldController = shield.GetComponent<ShieldController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");

        if (!usingShield)
        {
           if (Input.GetButtonDown("Fire1"))
            {
                tryFire1 = true;
            }
        }
 

        if (Input.GetButton("Fire2"))
        {
            tryFire2 = true;
        }
        else
        {
            tryFire2 = false;
            usingShield = false;
        }
    }

    public void FixedUpdate()
    {
        //if (transform.position.y < 3f) { gm.EmergencyRestart(); }

        //physics and movement
        Vector3 inputVector = (Vector3.forward * moveDirection.z) + (Vector3.right * moveDirection.x);
        rb.MovePosition(rb.position + inputVector * moveSpeed * Time.fixedDeltaTime);

        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitdist = 0.0f;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);

            shieldHealth = shieldController.health;
            if (tryFire2 && shieldHealth > 0)
            {
                usingShield = true;
                shield.SetActive(true);
            }
            else
            {
                usingShield = false;
                shield.SetActive(false);
                if (tryFire1)
                {
                    GameObject bullet = Instantiate(projectile, muzzleTip.position, muzzleTip.rotation);
                    Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
                    bulletRB.AddForce(muzzleTip.forward * bulletForce, ForceMode.Impulse);
                    tryFire1 = false;
                }
            }


        }



 

 

    }
}
