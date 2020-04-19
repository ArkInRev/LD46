using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VignetteManager : MonoBehaviour
{
    public GameObject[] vignettes; //vignettes in the game
    public GameObject playerStartVignette; //special player start object
    public GameObject larvaStartVignette; //special larva start object
    public Transform[] vignetteLocations; // locations to place vignettes
    public float[] rotations = { 0.0f, 90f, 180f, 270f }; // rotation of placed vignette

    public GameObject spawnItemParent;

    private List<Transform> listVignettes;
    private List<Transform> shufflingVignettes;

    private List<Transform> shuffledVignettes;

    private GameObject goInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        listVignettes = new List<Transform>();
        shufflingVignettes = new List<Transform>();
        shuffledVignettes = new List<Transform>();


        //add vignette locations to a list 
        Debug.Log("Vignette transforms in array: " + vignetteLocations.Length);
        for (int i = 0; i<vignetteLocations.Length; i++)
        {
            listVignettes.Add(vignetteLocations[i]);
            shufflingVignettes.Add(vignetteLocations[i]); //initialize randomizing list;
        }
        Debug.Log("Shuffling Vignette list length: " + shufflingVignettes.Count);

        // set the larva start location
        Transform larvaSpawn = randomListVignetteTransform();
        goInstantiated = Instantiate(larvaStartVignette, larvaSpawn.position, GetSpawnRotation(randomPrefabRotation()));
        goInstantiated.transform.SetParent(spawnItemParent.transform) ;

        //set the player start location
        Transform playerSpawn = randomListVignetteTransform();
        goInstantiated = Instantiate(playerStartVignette, playerSpawn.position, GetSpawnRotation(randomPrefabRotation()));
        goInstantiated.transform.SetParent(spawnItemParent.transform);
        //set the rest of the level up
        while (shufflingVignettes.Any())
        {
            Transform thisVignette = randomListVignetteTransform();
            goInstantiated = Instantiate(randomPrefab(), thisVignette.position, GetSpawnRotation(randomPrefabRotation()));
            goInstantiated.transform.SetParent(spawnItemParent.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Transform randomListVignetteTransform()
    {
        Transform selectedVignetteTransform;
        
        int index = Random.Range((int)0,(int)shufflingVignettes.Count);
        selectedVignetteTransform = shufflingVignettes[index];
        shufflingVignettes.RemoveAt(index);
        shuffledVignettes.Add(selectedVignetteTransform);
        return selectedVignetteTransform;
    }

    float randomPrefabRotation()
    {
        float randomRot;
        int randIndex = Random.Range((int)0, rotations.Length);
        randomRot = rotations[randIndex];

        return randomRot;
    }

    GameObject randomPrefab()
    {
        GameObject randomGO;
        int randIndex = Random.Range((int)0, vignettes.Length);
        randomGO = vignettes[randIndex];

        return randomGO;
    }

    Quaternion GetSpawnRotation(float rotationAngle)
    {
        Quaternion rotationQ = Quaternion.identity;
        rotationQ.eulerAngles = new Vector3(0, rotationAngle, 0);


        return rotationQ;
    }
}
