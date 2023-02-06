using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameScript : MonoBehaviour
{
    /*public int width = 10;
    public int height = 10;
    public GameObject prefab;*/
    // Start is called before the first frame update
    private bool goingUp = true;
    public void Start()
    {
        //Instantiate(prefab, new Vector3(width / 2 - 2, (float)0.1, height / 2 - 1), Quaternion.identity);
    }


    // Update is called once per frame
    public void Update()
    {
        if (goingUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            if(transform.position.y >= 2)
                goingUp = false;
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime, Space.World);
            if (transform.position.y <= 0)
                goingUp = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Small_Cannon" || collision.gameObject.name == "Small_cannon" 
            || collision.gameObject.name == "Small_cannon_Wheel_L" || collision.gameObject.name == "Small_cannon_Aim" || collision.gameObject.name == "Small_cannon_Wheel_S")
        {
            MazeR.completed = true;
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
            SceneManager.LoadScene("Outro", LoadSceneMode.Single);
            //collision.gameObject.GetComponent<cannon>().player_entered_house = true;
        }
    }
}
