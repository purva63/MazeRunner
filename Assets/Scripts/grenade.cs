
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
    public GameObject virusPrefab;
    public GameObject cannon;
    private int maxClones;
    private int counter = 0;
    private float currhealth;
    private AudioSource src;
    private AudioClip gnd;
    private float radius_of_search_for_player;
    private float virus_speed;

    void Start()
    {
        maxClones = 30;
        counter = 0;
        src = cannon.GetComponent<AudioSource>();
        gnd = cannon.GetComponent<cannon>().grenadeSound;
        radius_of_search_for_player = 1.0F;
        virus_speed = 0.2f;

        while (counter <= maxClones)
        {
            Vector3 randomSpawnZone = new Vector3(Random.Range(-5, 5), 0.1f, Random.Range(-5, 5));
            if (randomSpawnZone.x != 0 && randomSpawnZone.y != 0 && randomSpawnZone.z != 0f)
            {
                GameObject newobject = Instantiate(virusPrefab, randomSpawnZone, Quaternion.identity);
                newobject.name = "Grenade";
                newobject.transform.localScale += new Vector3(0.5F,0.5F,0.5F);
                newobject.AddComponent<SphereCollider>();
                newobject.AddComponent<Rigidbody>();
                newobject.GetComponent<Rigidbody>().useGravity = false;
                //newobject.GetComponent<SphereCollider>().isTrigger = true;
                cannon.GetComponent<cannon>().listGrenades.Add(newobject);
            }

            counter += 1;
        }

    }

    void Update()
    {
        //GameObject cannonball = GameObject.Find("Small_Cannon");


        for (int i = 0; i < cannon.GetComponent<cannon>().listGrenades.Count; i++)
        {
            Vector3 vicinity = cannon.GetComponent<cannon>().listGrenades[i].transform.position - cannon.transform.position;

            //Debug.Log("In Update with vicinity:" + vicinity + ":" + vicinity.magnitude + ":" + radius_of_search_for_player);

            if (vicinity.magnitude <= radius_of_search_for_player && cannon.GetComponent<cannon>().listGrenades[i] != null)
            {
                Vector3 dir = (cannon.transform.position - cannon.GetComponent<cannon>().listGrenades[i].transform.position);
                dir = dir / dir.magnitude;
                dir.y = 0;
                cannon.GetComponent<cannon>().listGrenades[i].transform.position += dir * virus_speed * Time.deltaTime;

                //Debug.Log("Insideee" + cannon.GetComponent<cannon>().listGrenades[i].transform.position);
            }

        }



    }

    
    


}