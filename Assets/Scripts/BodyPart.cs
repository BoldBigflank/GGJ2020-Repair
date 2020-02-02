using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPartTypes
{
    Head,
    Torso,
    Feet
}

public enum AnimalType
{
    Cat = 0,
    Chameleon,
    Cow,
    Dog,
    Frog,
    Giraffe,
    Hamster,
    Koala,
    Toucan,
    Lemur,
    Octopus
}



public class BodyPart : MonoBehaviour
{
    public BodyPartTypes type = BodyPartTypes.Torso;
    private Collider2D assemblyZoneCollider;
    private bool isInAssemblyZone = false;

    
    public AnimalType animalType;
    private bool isStolen;
    
    
    [SerializeField]
    public bool isHead = false;
    [SerializeField]
    public bool isRightLimb = false;

    private AssemblyZone.PlacementPoint savedPoint;

    private bool isBeingDestroyed = false;
    private Vector3 destructionScaleDownSpeed;

    // Start is called before the first frame update
    void Start()
    {
        isStolen = false;   //Change this to true if taken from another player!!!!
        destructionScaleDownSpeed = new Vector3(0.001f, 0.001f, 0.001f);
        //Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        //gameObject.GetComponent<BoxCollider2D>().size = S;
        //gameObject.GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(isBeingDestroyed)
        {
            transform.localScale -= destructionScaleDownSpeed;
            if(transform.localScale.x <= 0.01f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Hole")
        {
            //Debug.Log("Body part collided with hole!!!");
            StartDestruction();
        }
    }

    public void PlaceInAssemblyZone(Collider2D col)
    {
        assemblyZoneCollider = col;
        isInAssemblyZone = true;
    }

    public void AssignPlacementPoint(AssemblyZone.PlacementPoint point)
    {
        savedPoint = point;
    }

    public AssemblyZone.PlacementPoint GetPlacementPoint()
    {
        return savedPoint;
    }

    public void StartDestruction()
    {
        isBeingDestroyed = true;
    }

    public void PickUp()
    {
        gameObject.GetComponent<PathFinder>().enabled = false;
        if(isInAssemblyZone)
        {
            RemoveFromAssemblyZone();
        }
    }

    public void RemoveFromAssemblyZone()
    {
        assemblyZoneCollider.gameObject.GetComponent<AssemblyZone>().RemoveBodyPart(this);
    }

    public bool GetIsStolen()
    {
        return isStolen;
    }
}
