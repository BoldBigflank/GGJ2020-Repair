using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager
{
    private static GameStateManager instance;

    private AssemblyZone assemblyZoneP1;
    private AssemblyZone assemblyZoneP2;
    private AssemblyZone assemblyZoneP3;
    private AssemblyZone assemblyZoneP4;

    private int scoreP1 = 0;
    private int scoreP2 = 0;
    private int scoreP3 = 0;
    private int scoreP4 = 0;

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
        scoreP1 = 0;
    }

    private void privInitializeP2(AssemblyZone zone)
    {
        assemblyZoneP2 = zone;
        scoreP2 = 0;
    }

    private void privInitializeP3(AssemblyZone zone)
    {
        assemblyZoneP3 = zone;
        scoreP3 = 0;
    }

    private void privInitializeP4(AssemblyZone zone)
    {
        assemblyZoneP4 = zone;
        scoreP4 = 0;
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
}
