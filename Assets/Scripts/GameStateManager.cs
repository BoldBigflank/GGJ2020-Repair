using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager
{
    private static GameStateManager instance;

    [SerializeField] static int totalRounds = 1;
    private int numberOfPlayers = 2;
    private int round = 0;

    private AssemblyZone assemblyZoneP1;
    private AssemblyZone assemblyZoneP2;
    private AssemblyZone assemblyZoneP3;
    private AssemblyZone assemblyZoneP4;

    private int scoreP1 = 0;
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

    public static void InitializeP1(AssemblyZone zone)
    {
        Instance().privInitializeP1(zone);
    }

    public static void InitializeP2(AssemblyZone zone)
    {
        Instance().privInitializeP2(zone);
    }

    public static void InitializeP3(AssemblyZone zone)
    {
        Instance().privInitializeP3(zone);
    }

    public static void InitializeP4(AssemblyZone zone)
    {
        Instance().privInitializeP4(zone);
    }

    private void privInitializeP1(AssemblyZone zone)
    {
        assemblyZoneP1 = zone;
    }

    private void privInitializeP2(AssemblyZone zone)
    {
        assemblyZoneP2 = zone;
    }

    private void privInitializeP3(AssemblyZone zone)
    {
        assemblyZoneP3 = zone;
    }

    private void privInitializeP4(AssemblyZone zone)
    {
        assemblyZoneP4 = zone;
    }

    public static AssemblyZone GetAssemblyZoneP1()
    {
        return Instance().assemblyZoneP1;
    }

    public static AssemblyZone GetAssemblyZoneP2()
    {
        return Instance().assemblyZoneP2;
    }

    public static AssemblyZone GetAssemblyZoneP3()
    {
        return Instance().assemblyZoneP3;
    }

    public static AssemblyZone GetAssemblyZoneP4()
    {
        return Instance().assemblyZoneP4;
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
