using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{

    private ControllerState[] controllerStates;
    [SerializeField] int maxContollers = 4;
    private int connectedControllers = 0;
    // Start is called before the first frame update
    public void Initialize()
    {
        controllerStates = new ControllerState[maxContollers];
        for (int i = 0; i < maxContollers; i++)
        {
            controllerStates[i] = new ControllerState();
            controllerStates[i].SetInputSpot(i + 1);
        }
    }

    void FixedUpdate()
    {
        int inputSpot = 1;
        int controllerNumber = 0;
        foreach (string controllerName in Input.GetJoystickNames())
        {
            if (controllerName.Length > 0)
            {
                controllerStates[controllerNumber].SetInputSpot(inputSpot);
                controllerNumber++;
            }
            inputSpot++;
            if (controllerNumber >= maxContollers)
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
