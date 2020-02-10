﻿using System.Collections;
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
    private Vector2 holePosition;

    // Start is called before the first frame update
    void Start()
    {
        isStolen = false; 
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
            float step = 1.2f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, holePosition, step);
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
            holePosition = col.transform.position;
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
        pointPlacedIn.SetBodyPart(null);
        pointPlacedIn = null;
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
