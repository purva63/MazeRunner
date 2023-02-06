using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundShot : MonoBehaviour
{
    private GameObject cannon;
    // Start is called before the first frame update
    void Start()
    {
        cannon = GameObject.Find("Small_Cannon");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Inside oncollision" + ":" + collision.gameObject.name);
        if (collision.gameObject.name == "Grenade")
        {
            cannon.GetComponent<cannon>().listGrenades.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
