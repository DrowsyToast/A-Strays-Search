using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    [SerializeField] private float startDelay = 3;
    [SerializeField] private float spawnInterval = 5;
    [SerializeField] private float spawnRangeX = 20;
    [SerializeField] private float spawnPosZ = 20;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomItem", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomItem()
    {
        int itemIndex = Random.Range (0, itemPrefabs.Length);
        Vector3 spawnpos = new Vector3(Random.Range(-xSpawnRange, xSpawnRange), 0, zSpawnPos);
        Instantiate(itemPrefabs[itemIndex], new Vector3(0, 0, 20) spawnpos, itemPrefabs[itemIndex].transform.rotation);
    }

}
