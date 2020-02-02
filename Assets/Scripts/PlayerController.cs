﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Sprites to swap to
    [SerializeField]
    private Sprite spriteLookingUp;
    [SerializeField]
    private Sprite spriteLookingDown;
    [SerializeField]
    private Sprite spriteLookingRight;
    [SerializeField]
    private Sprite spriteLookingLeft;
    private SpriteRenderer spriteRenderer;

    //Grabbing and dropping mechanic
    private Collider2D pickUpCollider;
    private Collider2D assemblyZoneCollider;

    //Movement Attributes
    private Rigidbody2D rigidbody2D;
    private Vector2 velocity;
    public float moveSpeed = 10.0f;
    
    //Current state booleans
    private bool isHoldingInteractable = false;
    private bool isWithinPickupRange = false;
    private bool isInsideAssemblyZone = false;


    //Create or grab the necessary movement objects
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        velocity = new Vector2(0.0f, 0.0f);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //Move the rigidbody
        rigidbody2D.MovePosition(rigidbody2D.position + velocity * Time.deltaTime);

        //Rotate this player
        if(velocity.y > 0.0f && velocity.y > velocity.x)
        {
            spriteRenderer.sprite = spriteLookingUp;
        }
        else if(velocity.x > 0.0f)
        {
            spriteRenderer.sprite = spriteLookingRight;
        }
        else if(velocity.x < velocity.y)
        {
            spriteRenderer.sprite = spriteLookingLeft;
        }
        else if(velocity.y < 0.0f)
        {
            spriteRenderer.sprite = spriteLookingDown;
        }

        //If you are holding an object, make sure it follows you
        if(isHoldingInteractable)
        {
            pickUpCollider.transform.position = transform.position;
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
        pickUpCollider.gameObject.GetComponent<BodyPart>().PickUp();
    }

    void DropInteractable()
    {
        if(isInsideAssemblyZone)
        {
            pickUpCollider.GetComponent<BodyPart>().PlaceInAssemblyZone(assemblyZoneCollider);
            assemblyZoneCollider.GetComponent<AssemblyZone>().DropOffBodyPart(pickUpCollider.GetComponent<BodyPart>());
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
