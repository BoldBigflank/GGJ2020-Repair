using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLevelController : MonoBehaviour
{
    [SerializeField] float timeRemaining = 60.0f;
    [SerializeField] GameObject[] players;
    [SerializeField] GameObject[] assemblyZonesObjects;
    [SerializeField] Text timer, targetAnimalText, penaltyAnimalText;
    private AudioSource buzzer, songWithoutHorns, songWithHorns;
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
        buzzer = GetComponents<AudioSource>()[0];
        songWithoutHorns = GetComponents<AudioSource>()[1];
        songWithHorns = GetComponents<AudioSource>()[2];
        songWithoutHorns.Play();
        songWithHorns.Play();
        songWithHorns.volume = 0f;
        //GameStateManager.SetNumberOfPlayers(2);
        AssemblyZone[] assemblyZones = new AssemblyZone[4];
        for (int i = 0; i < 4; i++)
        {
            assemblyZones[i] = assemblyZonesObjects[i].GetComponent<AssemblyZone>();
        }
        int numPlayers = GameStateManager.GetNumberOfPlayers();
        if (numPlayers < 4)
        {
            assemblyZonesObjects[3].SetActive(false);
            players[3].SetActive(false);
        }
        if (numPlayers < 3)
        {
            assemblyZonesObjects[2].SetActive(false);
            players[2].SetActive(false);
        }

    }

    void FixedUpdate()
    {
        timeRemaining -= Time.deltaTime;

        if(timeRemaining <= 10.0f)
        {
            if(!finalPhaseStarting)
            {
                finalPhaseStarting = true;
                buzzer.Play();
                songWithoutHorns.volume = 0f;
                songWithHorns.volume = 1f;
            }

            if(timeRemaining <= 0.0f)
            {
                int numPlayers = GameStateManager.GetNumberOfPlayers();
                LinkedList<BodyPart>[] bodyPartLists = new LinkedList<BodyPart>[numPlayers];
                for (int i = 0; i < numPlayers; i++)
                {
                    bodyPartLists[i] = assemblyZonesObjects[i].GetComponent<AssemblyZone>().GetBodyParts();
                }
                GameStateManager.SetBodyPartLists(bodyPartLists);
                SceneManager.LoadScene("RevealScreen", LoadSceneMode.Single);
            }
        }
        int minutes = (int)timeRemaining / 60;
        int seconds = (int)timeRemaining % 60;
        if (seconds >= 10)
        {
            timer.text = minutes + ":" + seconds;
        }
        else
        {
            timer.text = minutes + ":0" + seconds;
        }


    }
}
