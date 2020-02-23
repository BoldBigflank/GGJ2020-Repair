using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager
{
    private static GameStateManager instance;

    private List<int> controllerSpotsToIgnore = null;
    private static int totalRounds = 3;
    private LinkedList<BodyPart>[] bodyPartLists;
    private CharacterSelector.CharacterColors[] characterColorsChosen;
    private int numberOfPlayers = 4;
    private int round = 0;

    private int scoreP1 = 0;    //Change it array
    private int scoreP2 = 0;
    private int scoreP3 = 0;
    private int scoreP4 = 0;

    private AnimalType targetAnimal;
    private AnimalType penaltyAnimal;

    private static GameStateManager Instance()
    {
        if(instance == null)
        {
            instance = new GameStateManager();
        }
        return instance;
    }

    public static void ResetGame()
    {
        Instance().round = 0;
        Instance().scoreP1 = 0;
        Instance().scoreP2 = 0;
        Instance().scoreP3 = 0;
        Instance().scoreP4 = 0;
    }

    public static List<int> GetControllerSpotsToIgnore()
    {
        if (Instance().controllerSpotsToIgnore == null)
        {
            Instance().controllerSpotsToIgnore = new List<int>();
            for (int i = 0; i < Input.GetJoystickNames().Length; i++)   //Ignore all blank connections
            {
                if (Input.GetJoystickNames()[i].Length == 0)
                {
                    Instance().controllerSpotsToIgnore.Add(i);
                }
            }
        }
        return Instance().controllerSpotsToIgnore;
    }

    public static void SetCharacterColorsChosen(CharacterSelector.CharacterColors[] characters)
    {
        Instance().characterColorsChosen = characters;
    }

    public static CharacterSelector.CharacterColors[] GetCharacterColorsChosen()
    {
        return Instance().characterColorsChosen;
    }

    public static void SetBodyPartLists(LinkedList<BodyPart>[] levelBodyPartLists)
    {
        Instance().bodyPartLists = levelBodyPartLists;
    }

    public static LinkedList<BodyPart> GetBodyPartLists(int player)
    {
        return Instance().bodyPartLists[player];
    }

    public static int GetNumberOfPlayers()
    {
        return Instance().numberOfPlayers;
    }

    public static void SetNumberOfPlayers(int num)
    {
        Instance().numberOfPlayers = num;
    }

    public static void AddScoreToPlayer(int player, int score)
    {
        if (player == 0)
        {
            Instance().scoreP1 += score;
        }
        else if (player == 1)
        {
            Instance().scoreP2 += score;
        }
        else if (player == 2)
        {
            Instance().scoreP3 += score;
        }
        else
        {
            Instance().scoreP4 += score;
        }
    }

    public static int GetPlayerScore(int player)
    {
        if (player == 0)
        {
            return Instance().scoreP1;
        } 
        else if (player == 1)
        {
            return Instance().scoreP2;
        }
        else if (player == 2)
        {
            return Instance().scoreP3;
        }
        else
        {
            return Instance().scoreP4;
        }
    }

    public static void SetTargetAnimal(AnimalType animalType)
    {
        Instance().targetAnimal = animalType;

    }

    public static AnimalType GetTargetAnimal()
    {
        return Instance().targetAnimal;

    }

    public static void SetPenaltyAnimal(AnimalType animalType)
    {
        Instance().penaltyAnimal = animalType;

    }

    public static AnimalType GetPenaltyAnimal()
    {
        return Instance().penaltyAnimal;

    }

    public static bool NextRound()  //True if end of game
    {
        Instance().round++;
        return Instance().round == totalRounds;
    }
}
