using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public GameObject enemyPrefab;
    [SerializeField] private float startDelay = 3;
    [SerializeField] private float spawnInterval = 5;
    [SerializeField] private float spawnRangeX = 20;
    [SerializeField] private float spawnRangeZ = 20;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomItem", startDelay, spawnInterval);

        playerControllerScript = GameObject.Find ("Player").GetComponent<PlayerController>();

        Instantiate(enemyPrefab, new Vector3(-11.5f, 0.6f, -10.8f), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomItem()
    {
        if (playerControllerScript.gameOver == false)
        {
        int itemIndex = Random.Range (0, itemPrefabs.Length);
        Vector3 spawnpos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.5f, Random.Range(-spawnRangeZ,spawnRangeZ));
        Instantiate(itemPrefabs[itemIndex], spawnpos, itemPrefabs[itemIndex].transform.rotation);
        }
    }

}
