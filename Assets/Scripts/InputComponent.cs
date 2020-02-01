using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    public PlayerController player;
    public string playerName = "1";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player.Move(Input.GetAxisRaw("JoyStick" + playerName + "X"), Input.GetAxisRaw("JoyStick" + playerName + "Y"));
    }
}
