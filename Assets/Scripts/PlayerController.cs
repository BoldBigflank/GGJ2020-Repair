using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(float x, float y)
    {
        transform.Translate(x * moveSpeed, 0.0f, 0.0f);
        transform.Translate(0.0f, y * moveSpeed, 0.0f);

        Debug.Log("X Value: " + x);
        //Debug.Log("Y Value: " + y);
    }

    public void Interact()
    {

    }
}
