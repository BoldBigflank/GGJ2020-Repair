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
    private int playerNumber = 1;

    private ControllerManager controllerManager;
    private ControllerState controller;

    private void Start()
    {
        controllerManager = GameObject.FindWithTag("GameController").GetComponent<ControllerManager>();
        controller = controllerManager.GetControllerState(playerNumber);
    }

    void Update()
    {
        print(Input.GetJoystickNames().Length);
        //player.Move(Input.GetAxis(inputXAxis), Input.GetAxis(inputYAxis));
        if (controllerManager.GetConnectedControllers() > playerNumber)
        {
            // Do keyboard ones
            player.SetVelocityX(Input.GetAxis("Controller" + playerNumber + "_KeyX"));
            player.SetVelocityY(Input.GetAxis("Controller" + playerNumber + "_KeyY"));

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
