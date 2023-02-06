using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barrier : MonoBehaviour
{
    private string[,] easy = new string[,] { { "The energy by virtue of its position is known as", "Potential energy", "Kinetic energy", "Internal energy" },
    { "Which of these states of matter has the maximum density?", "Solid", "Liquid", "Gas" },
    {"What is the effect of increase of temperature on the speed of sound?","increases","decreases","no effect" },
    {"What is the fuel in the Sun?", "Hydrogen", "Helium", "Oxygen"},
    {"Nuclear sizes are expressed in a unit named", "Fermi", "Newton","Tesla" },
    {"The speed of light will be minimum while passing through" , "glass", "vaccum", "water" } };

    private GameObject text1, text1Back;
    private GameObject text2, text2Back;
    private Text questionFront, questionBack;
    private int correctIndex = 0;
    private int indexQuestion = 0;

    // Start is called before the first frame update
    void Start()
    {
        indexQuestion = Random.Range(0, easy.GetLength(0));
        correctIndex = Random.Range(0, 2);

        Debug.Log("Instantiated"+":"+indexQuestion+":"+correctIndex+":"+ transform.GetChild(0).gameObject + ":" + transform.GetChild(1).gameObject + ":" + transform.GetChild(2).gameObject + ":" + transform.GetChild(3).gameObject);

        text1 = transform.GetChild(0).gameObject;
        text2 = transform.GetChild(1).gameObject;
        text1Back = transform.GetChild(2).gameObject;
        text2Back = transform.GetChild(3).gameObject;
        questionFront = transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        questionBack = transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();

        Text txt1Val = text1.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text txt2Val = text2.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text txt1BackVal = text1Back.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text txt2BackVal = text2Back.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();


        if (correctIndex == 0)
        {
            txt1Val.text = easy[indexQuestion, 1];
            txt1BackVal.text = easy[indexQuestion, 1];
            txt2Val.text = easy[indexQuestion, 2];
            txt2BackVal.text = easy[indexQuestion, 2];
        }
        else
        {
            txt1Val.text = easy[indexQuestion, 2];
            txt1BackVal.text = easy[indexQuestion, 2];
            txt2Val.text = easy[indexQuestion, 1];
            txt2BackVal.text = easy[indexQuestion, 1];
        }
    }
    // Update is called once per frame
    void Update()
    {
        GameObject cannon = GameObject.Find("Small_Cannon");
        //Debug.Log("pos of cannon" + cannon.transform.position.z);
        Vector3 vicinity1 = cannon.transform.position - transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.transform.position;
        Vector3 vicinity2 = cannon.transform.position - transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.transform.position;
        if (vicinity2.magnitude < vicinity1.magnitude)
        {
            questionBack.text = "Question: "+easy[indexQuestion, 0];
            questionFront.text = "";
        }
        else
        {
            questionFront.text = "Question: " + easy[indexQuestion, 0];
            questionBack.text = "";
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider myCollider = collision.GetContact(0).thisCollider;
        Debug.Log("Triggered on: " + myCollider + "-----:-----" + correctIndex);
        if (correctIndex == 0 && (myCollider.name.Contains("option1") || myCollider.name.Contains("option1Back")) && collision.gameObject.name.Contains("Round_shot"))
        {
            Debug.Log("Triggered on:1---- " + collision.gameObject.name);
            gameObject.SetActive(false);
            Destroy(this,1.0F);
        }
        if (correctIndex == 1 && (myCollider.name.Contains("Option2") || myCollider.name.Contains("Option2Back")) && collision.gameObject.name.Contains("Round_shot"))
        {
            Debug.Log("Triggered on:2--- " + collision.gameObject.name);
            gameObject.SetActive(false);
            Destroy(this,1.0F);
        }
    }

    /*public void CollisionDetected(childCollision childScript)
    {
        Debug.Log("child collided");
    }*/

    
}
