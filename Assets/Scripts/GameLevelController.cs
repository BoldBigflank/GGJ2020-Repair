using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelController : MonoBehaviour
{
    public float timeRemaining = 60.0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if(timeRemaining <= 0.0f)
        {
            SceneManager.LoadScene("RevealScreen", LoadSceneMode.Single);
        }
    }
}
