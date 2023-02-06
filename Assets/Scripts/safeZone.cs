using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeZone : MonoBehaviour
{
    public GameObject zonePrefab;
    private GameObject smallCannon;
    public GameObject cannon;

    private int maxClones;
    private int counter = 0;
    void Start()
    {
        maxClones = 10;
    }
    // Update is called once per frame
    void Update()
    {


        while (counter <= maxClones)
        {
            Vector3 randomSpawnZone = new Vector3(Random.Range(-5, 5), 0.06f, Random.Range(-5, 5));
            if (randomSpawnZone.x != 0 && randomSpawnZone.y != 0 && randomSpawnZone.z != 0f)
            {
                GameObject newobject = Instantiate(zonePrefab, randomSpawnZone, Quaternion.identity);
                newobject.name = "SafeZone";
                newobject.AddComponent<BoxCollider>();
                counter += 1;
            }
        }


    }
}
