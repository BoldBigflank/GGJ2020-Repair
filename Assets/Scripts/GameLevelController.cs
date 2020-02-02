using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelController : MonoBehaviour
{
    public float timeRemaining = 60.0f;
    private bool finalPhaseStarting = false;

    void Start()
    {
        GameStateManager.SetPenaltyAnimal(AnimalType.Cat);
        GameStateManager.SetTargetAnimal(AnimalType.Dog);
        GameStateManager.SetNumberOfPlayers(2);  
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;

        if(timeRemaining <= 5.0f)
        {
            if(!finalPhaseStarting)
            {
                finalPhaseStarting = true;
                gameObject.GetComponent<AudioSource>().Play();
            }

            if(timeRemaining <= 0.0f)
            {
                SceneManager.LoadScene("RevealScreen", LoadSceneMode.Single);
            }
        }
        
    }
}
