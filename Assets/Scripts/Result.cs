using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject result;
    void Start()
    {
        if (MazeR.completed)
            result.GetComponent<Text>().text = "Congratulations " + PlayButton.name + ". You have successfully completed the game.";
        else
            result.GetComponent<Text>().text = "Oops " + PlayButton.name + ". You have lost the game.";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
