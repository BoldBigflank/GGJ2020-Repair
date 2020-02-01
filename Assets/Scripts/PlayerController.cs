using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Grabbing and dropping mechanic
    private Collider2D pickUpCollider;
    private Collider2D assemblyZoneCollider;

    //Movement Attributes
    private Rigidbody2D rigidbody2D;
    private Vector2 velocity;
    public float moveSpeed;
    
    //Current state booleans
    private bool isHoldingInteractable = false;
    private bool isWithinPickupRange = false;
    private bool isInsideAssemblyZone = false;


    //Create or grabe the necessary movement objects
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        velocity = new Vector2(0.0f, 0.0f);
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + velocity * Time.fixedDeltaTime);
        
        //If you are holding an object, make sure it follows you
        if(isHoldingInteractable)
        {
            pickUpCollider.gameObject.transform.position = transform.position;
        }
    }
    
    //Called by the input components to change how the player moves horizontally between -1.0f and 1.0f
    public void SetVelocityX(float x)
    {
        velocity.x = x * moveSpeed;
    }

    //Called by the input components to change how the player moves vertically between -1.0f and 1.0f
    public void SetVelocityY(float y)
    {
        velocity.y = y * moveSpeed;
    }

    //Called by the input components to trigger Interaction events
    public void Interact()
    {
        if(isHoldingInteractable)
        {
            DropInteractable();
        }
        else if(isWithinPickupRange)
        {
            PickUpInteractable();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(!isHoldingInteractable && col.gameObject.tag == "PickUp")
        {
            pickUpCollider = col;
            isWithinPickupRange = true;
        }
        else if(col.gameObject.tag == "Assembly Zone")
        {
            assemblyZoneCollider = col;
            EnterAssemblyZone();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "PickUp")
        {
            if(col == pickUpCollider)
            {
                isWithinPickupRange = false;
            }
        }
        else if(col.gameObject.tag == "Assembly Zone")
        {
            ExitAssemblyZone();
        }
    }

    void PickUpInteractable()
    {
        isHoldingInteractable = true;
        pickUpCollider.gameObject.GetComponent<Interactable>().PickedUpByPlayer();
    }

    void DropInteractable()
    {
        if(isInsideAssemblyZone)
        {
            assemblyZoneCollider.GetComponent<AssemblyZone>().DropOffInteractable(pickUpCollider);
        }

        isHoldingInteractable = false;
        pickUpCollider.gameObject.GetComponent<Interactable>().DroppedByPlayer();
    }

    void EnterAssemblyZone()
    {
        isInsideAssemblyZone = true;
    }

    void ExitAssemblyZone()
    {
        isInsideAssemblyZone = false;
    }
}
