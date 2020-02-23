using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{

    private ControllerState[] controllerStates;
    [SerializeField] int maxControllers = 4;
    private int connectedControllers = 0;
    private List<int> controllerSpotsToIgnore;

    public void Initialize()
    {
        controllerStates = new ControllerState[maxControllers];
        for (int i = 0; i < maxControllers; i++)
        {
            controllerStates[i] = new ControllerState();
        }
        controllerSpotsToIgnore = GameStateManager.GetControllerSpotsToIgnore();
    }

    void FixedUpdate()
    {
        int controllerNumber = 0;
        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            if (!controllerSpotsToIgnore.Contains(i))
            {
                if (Input.GetJoystickNames()[i].Length > 0)
                {
                    controllerStates[controllerNumber].SetInputSpot(i + 1);
                }
                else  //Disconnected controller
                {
                    controllerStates[controllerNumber].Deactivate();
                }
                controllerNumber++;
            }

            if (controllerNumber >= maxControllers)
            {
                break;
            }
        }
        connectedControllers = controllerNumber;
    }

    public ControllerState GetControllerState(int controllerNumber)
    {
        return controllerStates[controllerNumber];
    }

    public int GetConnectedControllers()
    {
        return connectedControllers;
    }

}
