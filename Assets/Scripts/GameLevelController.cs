using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLevelController : MonoBehaviour
{
    public float timeRemaining = 60.0f;
    [SerializeField] GameObject[] players;
    [SerializeField] Text timer, targetAnimalText, penaltyAnimalText;
    private bool finalPhaseStarting = false;

    void Start()
    {
        AnimalType targetAnimal = (AnimalType)Random.Range(0, 11);
        AnimalType penaltyAnimal = targetAnimal;
        while (targetAnimal == penaltyAnimal)
        {
            penaltyAnimal = (AnimalType)Random.Range(0, 11);
        }
        GameStateManager.SetPenaltyAnimal(penaltyAnimal);
        GameStateManager.SetTargetAnimal(targetAnimal);
        targetAnimalText.text = "Target Animal: " + targetAnimal.ToString();
        penaltyAnimalText.text = "Penalty Animal: " + penaltyAnimal.ToString();
        //GameStateManager.SetNumberOfPlayers(2);
        int numPlayers = GameStateManager.GetNumberOfPlayers();
        if (numPlayers < 4)
        {
            players[3].SetActive(false);
        }
        if (numPlayers < 3)
        {
            players[2].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;

        if(timeRemaining <= 10.0f)
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
        int minutes = (int)timeRemaining / 60;
        int seconds = (int)timeRemaining % 60;
        if (seconds > 10)
        {
            timer.text = minutes + ":" + seconds;
        }
        else
        {
            timer.text = minutes + ":0" + seconds;
        }


    }
}
