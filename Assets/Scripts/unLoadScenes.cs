using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class unLoadScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.UnloadSceneAsync(1);
        SceneManager.UnloadSceneAsync(2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
