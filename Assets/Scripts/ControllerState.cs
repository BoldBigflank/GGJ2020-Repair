using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerState : MonoBehaviour
{
    private int inputSpot = 1;
    private bool active = false;

    public void SetInputSpot(int newControllerNumber)
    {
        inputSpot = newControllerNumber;
        Activate();
    }

    private void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }

    public bool IsActive()
    {
        return active;
    }

    public float GetXAxis()
    {
        return Input.GetAxis("Controller" + inputSpot + "_X");
    }

    public float GetYAxis()
    {
        return Input.GetAxis("Controller" + inputSpot + "_Y");
    }

    public bool GetAButtonDown()
    {
        return Input.GetButtonDown("Controller" + inputSpot + "_A");
    }
}
