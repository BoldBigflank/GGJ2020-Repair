using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerState : MonoBehaviour
{
    private int inputSpot;
    // Start is called before the first frame update
    void Start()
    {
        inputSpot = 1;
    }

    public void SetInputSpot(int newControllerNumber)
    {
        inputSpot = newControllerNumber;
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
