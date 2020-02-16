using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponentController : MonoBehaviour
{
    //Reference to the player that should be affected by this component
    private PlayerController player;

    //Unity Input Axis names
    private string inputName = "Controller";

    private bool isKeyDown = false;

    public void SetControllerNumber(int playerNumber)
    {
        inputName = "Controller" + (playerNumber + 1);  //Controllers start at 1, not 0
    }

    private void Start()
    {
        player = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        //player.Move(Input.GetAxis(inputXAxis), Input.GetAxis(inputYAxis));
        if (Input.GetJoystickNames().Length <= 1)   //Always one blank controller for some reason
        {
            
            // Do keyboard ones
            player.SetVelocityX(Input.GetAxis(inputName + "_KeyX"));
            player.SetVelocityY(Input.GetAxis(inputName + "_KeyY"));

            if(isKeyDown)
            {
                if (!Input.GetButtonDown(inputName + "_KeyA"))
                {
                    isKeyDown = false;
                }
            }
            else
            {
                if (Input.GetButtonDown(inputName + "_KeyA"))
                {
                    player.Interact();
                    isKeyDown = true;
                }
            }

        } else
        {
            player.SetVelocityX(Input.GetAxis(inputName + "_X"));
            player.SetVelocityY(Input.GetAxis(inputName + "_Y"));

            if(isKeyDown)
            {
                if (!Input.GetButtonDown(inputName + "_A"))
                {
                    isKeyDown = false;
                }
            }
            else
            {
                if (Input.GetButtonDown(inputName + "_A"))
                {
                    player.Interact();
                    isKeyDown = true;
                }
            }
            
        }
        
    }
}
