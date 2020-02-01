using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponentController : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private string inputXAxis = "Controller1X";
    [SerializeField]
    private string inputYAxis = "Controller1Y";
    [SerializeField]
    private string inputInteractButton = "Controller1Interact";

    private bool isIteractButtonDown = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //player.Move(Input.GetAxis(inputXAxis), Input.GetAxis(inputYAxis));
        player.SetVelocityX(Input.GetAxis(inputXAxis));
        player.SetVelocityY(Input.GetAxis(inputYAxis));
        DetectInteractButtonState();
        //Debug.Log(Input.GetAxis(inputInteractButton));
        //Debug.Log(Input.GetKeyDown("joystick 1 button 1"));
    }

    private void DetectInteractButtonState()
    {
        if(isIteractButtonDown)
        {
            if(Input.GetAxis(inputInteractButton) == 0.0f) //Button was released
            {
                isIteractButtonDown = false;
                //Debug.Log(Input.GetAxis(inputInteractButton));
            }
        }
        else
        {
            if(Input.GetAxis(inputInteractButton) > 0.0f) //Button was pressed
            {
                player.Interact();
                //Debug.Log(Input.GetAxis(inputInteractButton));
                isIteractButtonDown = true;
            }   
        }
    }
}
