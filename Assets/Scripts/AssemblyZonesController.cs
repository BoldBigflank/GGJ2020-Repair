using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyZonesController : MonoBehaviour
{
    public AssemblyZone zone1;
    public AssemblyZone zone2;
    public AssemblyZone zone3;
    public AssemblyZone zone4;


    // Start is called before the first frame update
    void Start()
    {
        GameStateManager.InitializeP1(zone1);
        GameStateManager.InitializeP2(zone2);
        GameStateManager.InitializeP3(zone3);
        GameStateManager.InitializeP4(zone4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
