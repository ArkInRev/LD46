using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickup : MonoBehaviour, IInteractable
{
    private GameManager gm;
    public float energyGain;
    public CapsuleCollider cc;
    public ShieldController sc;
    public GameObject player;
    public ParticleSystem pickupEffect;

    public Transform initialParent;

    public GameObject spawnParentGO;
    GameObject goInstantiated;

    public void Interact()
    {
        //throw new System.NotImplementedException();
        if(sc.health < sc.maxHealth)
        {
            sc.Heal(energyGain);
            Instantiate(pickupEffect, transform.position,Quaternion.identity);
            Destroy(initialParent.gameObject);
        }




    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        player = GameObject.FindWithTag("Player");
        energyGain = gm.GetEnergyGain();
        sc = player.GetComponent<PlayerController>().shieldGO.GetComponent<ShieldController>();

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
