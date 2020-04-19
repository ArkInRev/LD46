using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNAPickup : MonoBehaviour, IInteractable
{
    private GameManager gm;
    public CapsuleCollider cc;
    public PlayerController pc;
    public GameObject player;
    public ParticleSystem pickupEffect;

    public void Interact()
    {
        //throw new System.NotImplementedException();

        pc.PickupDNA();
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);




    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        player = GameObject.FindWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interact();
        }
    }
}
