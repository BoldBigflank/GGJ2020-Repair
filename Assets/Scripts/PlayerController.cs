using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Sprites to swap to
    [SerializeField] Sprite spriteLookingUp;
    [SerializeField] Sprite spriteLookingDown;
    [SerializeField] Sprite spriteLookingRight;
    [SerializeField] Sprite spriteLookingLeft;
    private SpriteRenderer spriteRenderer;

    //Grabbing and dropping mechanic
    private GameObject bodyPartHeld;
    private List<GameObject> bodyPartsWithinRange;
    private GameObject ownAssemblyZone;
    private AssemblyZone assemblyZoneWithinRange;
    private GameLevelController gameLevelController;
    private AudioSource footstepSound, pickupSquish, placeSquish;

    //Movement Attributes
    private Rigidbody2D rigidbody2D;
    private Vector2 velocity;
    [SerializeField] float moveSpeed = 7.0f;

    //Current state booleans
    private bool isWithinPickupRange = false;
    private bool isInsideAssemblyZone = false;
    private bool isTeleporting = false;

    private Vector2 teleporationPoint;

    //Create or grab the necessary movement objects
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        velocity = new Vector2(0.0f, 0.0f);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        bodyPartsWithinRange = new List<GameObject>();
        gameLevelController = GameObject.FindGameObjectWithTag("Level Controller").GetComponent<GameLevelController>();
        footstepSound = GetComponents<AudioSource>()[0];
        pickupSquish = GetComponents<AudioSource>()[1];
        placeSquish = GetComponents<AudioSource>()[2];
    }

    void FixedUpdate()
    {
        if(isTeleporting)
        {
            rigidbody2D.MovePosition(teleporationPoint);
            isTeleporting = false;
        }
        else
        {
            rigidbody2D.MovePosition(rigidbody2D.position + velocity * Time.deltaTime);
        }

        bool isMoving = true;
        //Rotate this player
        if (velocity.y > 0.0f && velocity.y > velocity.x)
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
        else
        {
            isMoving = false;
            if (footstepSound.isPlaying)
            {
                footstepSound.Stop();
            }
        }

        if(isMoving && !footstepSound.isPlaying)
        {
            footstepSound.Play();
        }

        //If you are holding an object, make sure it follows you
        if(IsHoldingBodyPart())
        {
            if (!bodyPartHeld.GetComponent<BodyPart>().IsBeingDestroyed())
            {
                bodyPartHeld.transform.position = transform.position;
            }
            else
            {
                bodyPartHeld = null;
            }
        }
    }

    private bool IsHoldingBodyPart()
    {
        return bodyPartHeld != null;
    }

    public void Teleport(Vector2 posititionToTeleportTo, bool sidePortal)
    {
        if (sidePortal) 
        {
            posititionToTeleportTo.y = transform.position.y;
        }
        else
        {
            posititionToTeleportTo.x = transform.position.x;
        }

        teleporationPoint = posititionToTeleportTo;
        isTeleporting = true;
    }
    
    //Called by the input components to change how the player moves horizontally between -1.0f and 1.0f
    public void SetVelocityX(float x)
    {
        velocity.x = x * moveSpeed;
    }

    public float GetVelocityX()
    {
        return velocity.x;
    }

    //Called by the input components to change how the player moves vertically between -1.0f and 1.0f
    public void SetVelocityY(float y)
    {
        velocity.y = y * moveSpeed;
    }

    public float GetVelocityY()
    {
        return velocity.y;
    }

    //Called by the input components to trigger Interaction events
    public void Interact()
    {
        if(IsHoldingBodyPart())
        {
            DropBodyPart();
        }
        else if(isWithinPickupRange)
        {
            PickUpBodyPart();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "PickUp")
        {
            bodyPartsWithinRange.Add(col.gameObject);
            isWithinPickupRange = true;
        }
        else if(col.gameObject.tag == "Assembly Zone")
        {
            assemblyZoneWithinRange = col.gameObject.GetComponent<AssemblyZone>();
            isInsideAssemblyZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "PickUp")
        {
            bodyPartsWithinRange.Remove(col.gameObject);
            if(bodyPartsWithinRange.Count == 0)
            {
                isWithinPickupRange = false;
            }
        }
        else if(col.gameObject.tag == "Assembly Zone")
        {
            isInsideAssemblyZone = false;
        }
    }

    public void SetOwnAssemblyZone(GameObject assemblyZone)
    {
        ownAssemblyZone = assemblyZone;
    }

    void PickUpBodyPart()
    {
        float closestRange = 1000f;
        GameObject closestPart = null;
        foreach (GameObject bodyPart in bodyPartsWithinRange)
        {
            BodyPart bodyPartScript = bodyPart.GetComponent<BodyPart>();
            if (Vector2.Distance(transform.position, bodyPart.transform.position) < closestRange &&
                !bodyPartScript.IsBeingDestroyed() &&
                !bodyPartScript.IsHeld() &&
                (!gameLevelController.IsFinalPhase() || !bodyPartScript.IsInDifferentAssemblyZone(ownAssemblyZone))
                )
            {
                closestRange = Vector2.Distance(transform.position, bodyPart.transform.position);
                closestPart = bodyPart;
            }
        }
        if (closestPart != null)
        {
            pickupSquish.Play();
            closestPart.GetComponent<BodyPart>().PickUp();
            bodyPartHeld = closestPart;
        }
    }

    void DropBodyPart()
    {
        BodyPart bodyPart = bodyPartHeld.GetComponent<BodyPart>();
        if (isInsideAssemblyZone)
        {
            if ((bodyPart.IsHead() && assemblyZoneWithinRange.HasLessThanOneHead())
                || !bodyPart.IsHead() && assemblyZoneWithinRange.HasLessThanFourLimbs())
            {
                AssemblyZone.PlacementPoint placementPoint = assemblyZoneWithinRange.DropOffBodyPart(bodyPart);
                if (placementPoint != null)
                {
                    placeSquish.Play();
                    bodyPart.PutInAssemblyZone(placementPoint);
                    bodyPartHeld = null;
                }
            }
        }
        else
        {
            placeSquish.Play();
            bodyPart.DropOnFloor();
            bodyPartHeld = null;
        }
    }
}
