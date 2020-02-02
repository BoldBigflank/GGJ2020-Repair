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
    private string inputName = "Controller1";

    private bool isKeyDown = false;

    void Update()
    {
        //player.Move(Input.GetAxis(inputXAxis), Input.GetAxis(inputYAxis));
        if (Input.GetJoystickNames().Length == 0)
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
