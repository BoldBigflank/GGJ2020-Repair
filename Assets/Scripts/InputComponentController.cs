using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponentController : MonoBehaviour
{
    //Reference to the player that should be affected by this component
    private PlayerController player;

    //Unity Input Axis names
    private string inputName = "Controller";
    private int playerNumber;

    private bool isKeyDown = false;

    public void SetControllerNumber(int playerNumber)
    {
        inputName = "Controller" + (playerNumber + 1);  //Controllers start at 1, not 0
        this.playerNumber = playerNumber + 1;
    }

    private void Start()
    {
        player = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        //player.Move(Input.GetAxis(inputXAxis), Input.GetAxis(inputYAxis));
        if (Input.GetJoystickNames().Length - 1 < playerNumber)   //Always one blank controller for some reason
        {

            // Do keyboard ones
            float velX = Input.GetAxis(inputName + "_KeyX");
            float velY = Input.GetAxis(inputName + "_KeyY");
            player.SetVelocityX(velX);
            player.SetVelocityY(velY);
            
            if (velX != 0f && velY != 0f)
            {
                player.SetVelocityX(.7f * velX);
                player.SetVelocityY(.7f * velY);
            }

            if (isKeyDown)
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
