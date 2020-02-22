using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponentController : MonoBehaviour
{
    //Reference to the player that should be affected by this component
    private PlayerController player;

    //Unity Input Axis names
    [SerializeField]
    private int playerNumber = 1;

    private ControllerManager controllerManager;
    private ControllerState controller;

    private void Start()
    {
        player = gameObject.GetComponent<PlayerController>();
        controllerManager = GameObject.FindWithTag("Level Controller").GetComponent<ControllerManager>();
        controller = controllerManager.GetControllerState(playerNumber);
    }

    public void SetControllerNumber(int controllerNumber)
    {
        playerNumber = controllerNumber + 1; //controllerNumber starts at 0, playerNumber starts at 1
        controller = controllerManager.GetControllerState(playerNumber);
    }

    void Update()
    {
        if (controllerManager.GetConnectedControllers() > playerNumber)
        {
            // Do keyboard ones
            float velX = Input.GetAxis("Controller" + playerNumber + "_KeyX");
            float velY = Input.GetAxis("Controller" + playerNumber + "_KeyY");
            player.SetVelocityX(velX);
            player.SetVelocityY(velY);

            if (velX != 0f && velY != 0f)
            {
                player.SetVelocityX(.7f * velX);
                player.SetVelocityY(.7f * velY);
            }

            if (!Input.GetButtonDown("Controller" + playerNumber + "_KeyA")) {
                player.Interact();
            }
        } else
        {
            player.SetVelocityX(controller.GetXAxis());
            player.SetVelocityY(controller.GetYAxis());

            if (controller.GetAButtonDown())
            {
                player.Interact();
            }
        }
    }
}
