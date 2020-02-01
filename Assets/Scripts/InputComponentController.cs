using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponentController : MonoBehaviour
{
    //Reference to the player that should be affected by this component
    [SerializeField]
    private PlayerController player;

    //Unity Input Axis names
    [SerializeField]
    private string inputXAxis = "Controller1X";
    [SerializeField]
    private string inputYAxis = "Controller1Y";
    [SerializeField]
    private string inputInteractButton = "Controller1Interact";

    //Iteract button state boolean
    private bool isIteractButtonDown = false;

    void FixedUpdate()
    {
        //player.Move(Input.GetAxis(inputXAxis), Input.GetAxis(inputYAxis));
        player.SetVelocityX(Input.GetAxis(inputXAxis));
        player.SetVelocityY(Input.GetAxis(inputYAxis));
        DetectInteractButtonState();
    }

    private void DetectInteractButtonState()
    {
        if(isIteractButtonDown)
        {
            if(Input.GetAxis(inputInteractButton) == 0.0f) //Button was released
            {
                isIteractButtonDown = false;
            }
        }
        else
        {
            if(Input.GetAxis(inputInteractButton) > 0.0f) //Button was pressed
            {
                player.Interact();
                isIteractButtonDown = true;
            }   
        }
    }
}
