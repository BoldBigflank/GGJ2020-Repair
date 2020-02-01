using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Collider2D pickUpCollider;
    private Collider2D assemblyZoneCollider;

    private Rigidbody2D rigidbody2D;

    public float moveSpeed;
    private Vector2 velocity;
    private float dX;
    private float dY;

    private bool isHoldingInteractable = false;
    private bool isWithinPickupRange = false;
    private bool isInsideAssemblyZone = false;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        velocity = new Vector2(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(isHoldingInteractable)
        {
            pickUpCollider.gameObject.transform.position = transform.position;
        }
        rigidbody2D.MovePosition(rigidbody2D.position + velocity * Time.fixedDeltaTime);
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
        if(col.gameObject.tag == "PickUp")
        {
            pickUpCollider = col;
            isWithinPickupRange = true;
            Debug.Log("I can pick up an object now!");
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
                Debug.Log("I can no longer pick up an object now :(");
            }
        }
        else if(col.gameObject.tag == "Assembly Zone")
        {
            ExitAssemblyZone();
        }
    }

    void PickUpInteractable()
    {
        Debug.Log("I picked up the cube");
        isHoldingInteractable = true;
        pickUpCollider.gameObject.GetComponent<Interactable>().PickedUpByPlayer();
    }

    void DropInteractable()
    {
        if(isInsideAssemblyZone)
        {
            assemblyZoneCollider.GetComponent<AssemblyZone>().DropOffInteractable(pickUpCollider);
        }

        Debug.Log("I dropped the cube!!");
        isHoldingInteractable = false;
        pickUpCollider.gameObject.GetComponent<Interactable>().DroppedByPlayer();
    }

    void EnterAssemblyZone()
    {
        Debug.Log("Player has entered the Assembly zone");
        isInsideAssemblyZone = true;
    }

    void ExitAssemblyZone()
    {
        Debug.Log("Player has exited the Assembly zone");
        isInsideAssemblyZone = false;
    }
}
