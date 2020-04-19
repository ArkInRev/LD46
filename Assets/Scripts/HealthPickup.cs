using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour, IInteractable
{
    private GameManager gm;
    public float healthGain;
    public CapsuleCollider cc;
    public PlayerController pc;
    public GameObject player;
    public ParticleSystem pickupEffect;

    public Transform initialParent;

    public GameObject spawnParentGO;
    GameObject goInstantiated;

    public void Interact()
    {
        //throw new System.NotImplementedException();
        if (pc.health < pc.maxHealth)
        {
            pc.Heal(healthGain);
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            Destroy(initialParent.gameObject);
        }




    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        player = GameObject.FindWithTag("Player");
        healthGain = gm.GetHealthGain();
        pc = player.GetComponent<PlayerController>();

        initialParent = gameObject.transform.parent;

        spawnParentGO = GameObject.FindWithTag("MapGOTagger");
        goInstantiated = initialParent.gameObject;
        goInstantiated.transform.SetParent(spawnParentGO.transform);
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
