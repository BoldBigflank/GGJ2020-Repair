using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLevelController : MonoBehaviour
{
    [SerializeField] float timeRemaining = 60.0f;
    [SerializeField] GameObject[] assemblyZonesObjects;
    [SerializeField] GameObject[] playerPrefabs;    //0 = pink, 1 = blue, 2 = green, 3 = yellow
    [SerializeField] Text timer, targetAnimalText, penaltyAnimalText;
    private AudioSource buzzer, songWithoutHorns, songWithHorns;
    private bool finalPhaseStarting = false;

    private readonly Vector3[] playerSpawnLocations = { new Vector3(-6.84f, 5.01f, 25f),
                                                        new Vector3(6.78f, 5.01f, 25f),
                                                        new Vector3(6.78f, -5.87f, 25f),
                                                        new Vector3(-6.84f, -5.87f, 25f) };

    private readonly Color[] assemblyZoneColors = { new Color32(255, 109, 215, 255),
                                                    new Color32(0, 178, 255, 255),
                                                    new Color32(26, 195, 0, 255),
                                                    new Color32(241, 215, 0, 255) };

    void Start()
    {
        AnimalType targetAnimal = (AnimalType)Random.Range(0, (int)AnimalType.Size);
        AnimalType penaltyAnimal = targetAnimal;
        while (targetAnimal == penaltyAnimal)
        {
            penaltyAnimal = (AnimalType)Random.Range(0, (int)AnimalType.Size);
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
        int numPlayers = GameStateManager.GetNumberOfPlayers();
        CharacterSelector.CharacterColors[] colors = GameStateManager.GetCharacterColorsChosen();

        AssemblyZone[] assemblyZones = new AssemblyZone[numPlayers];
        for (int i = 0; i < numPlayers; i++)
        {
            assemblyZonesObjects[i].SetActive(true);
            assemblyZonesObjects[i].GetComponentsInChildren<SpriteRenderer>()[1].color = assemblyZoneColors[(int)colors[i]];
            assemblyZones[i] = assemblyZonesObjects[i].GetComponent<AssemblyZone>();
            GameObject playerPrefab = Instantiate(playerPrefabs[(int)(colors[i])], playerSpawnLocations[i], Quaternion.identity);
            playerPrefab.GetComponent<InputComponentController>().SetControllerNumber(i);
            playerPrefab.GetComponent<PlayerController>().SetOwnAssemblyZone(assemblyZonesObjects[i]);
        }
        
        for (int i = 3; i >= numPlayers; i--)    //Fix later with better instantiation
        {
            assemblyZonesObjects[i].SetActive(false);
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

    public bool IsFinalPhase()
    {
        return finalPhaseStarting;
    }

}
