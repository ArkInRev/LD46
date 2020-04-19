using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour,ISpawner
{
    private GameManager gm;
    public GameObject player;
    public Transform playerSpawnLocation;
    private PlayerController pc;

    public void Spawn(GameObject go, Transform spawnAt)
    {
        //Instantiate(go, spawnAt.position, spawnAt.rotation);
        go.transform.position = spawnAt.position;
        pc = player.GetComponent<PlayerController>();
        pc.maxHealth = gm.GetPlayerHealth();
        pc.shieldGO.GetComponent<ShieldController>().health = gm.GetPlayerShield();
        pc.health = pc.maxHealth;
        gm.PlayerHealthChange();
        gm.ShieldHealthChange();
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
       gm.onPlayerKilled += OnPlayerKilled;
        Spawn(player,playerSpawnLocation);
    }

    private void OnPlayerKilled()
    {
        Spawn(player, playerSpawnLocation);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        gm.onPlayerKilled -= OnPlayerKilled;
    }
}
