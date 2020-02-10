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

    public AnimalType animalType;
    private bool isStolen;

    private AssemblyZone.PlacementPoint pointPlacedIn;
    private AssemblyZone.PlacementPoint lastPointPlacedIn;

    private bool isBeingDestroyed = false;
    private Vector3 destructionScaleDownSpeed;

    // Start is called before the first frame update
    void Start()
    {
        isStolen = false;   //Change this to true if taken from another player!!!!
        destructionScaleDownSpeed = new Vector3(0.001f, 0.001f, 0.001f);
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
            StartDestruction();
        }
    }

    public bool IsHead()
    {
        return type == BodyPartTypes.Head;
    }

    public bool IsInAssemblyZone()
    {
        return pointPlacedIn != null;
    }

    public void AssignPlacementPoint(AssemblyZone.PlacementPoint point)
    {
        pointPlacedIn = point;
        if (lastPointPlacedIn != null && lastPointPlacedIn != point)
        {
            isStolen = true;
        }
        lastPointPlacedIn = point;
    }

    public AssemblyZone.PlacementPoint GetPlacementPoint()
    {
        return pointPlacedIn;
    }

    public void StartDestruction()
    {
        isBeingDestroyed = true;
    }

    public void PickUp()
    {
        gameObject.GetComponent<PathFinder>().enabled = false;
        if (IsInAssemblyZone())
        {
            RemoveFromAssemblyZone();
        }
    }

    public void RemoveFromAssemblyZone()
    {
        AssemblyZone.PlacementPoint placementPoint = GetPlacementPoint();
        placementPoint.SetBodyPart(null);
        transform.SetParent(null);
    }

    public bool IsBeingDestroyed()
    {
        return isBeingDestroyed;
    }

    public bool GetIsStolen()
    {
        return isStolen;
    }
}
