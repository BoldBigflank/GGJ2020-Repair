using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPartTypes
{
    Head,
    Torso,
    Feet
}

public class BodyPart : MonoBehaviour
{
    public BodyPartTypes type = BodyPartTypes.Torso;
    private Collider2D assemblyZoneCollider;
    private bool isInAssemblyZone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    public void PlaceInAssemblyZone(Collider2D col)
    {
        assemblyZoneCollider = col;
        isInAssemblyZone = true;
    }

    public void PickUp()
    {
        if(isInAssemblyZone)
        {
            RemoveFromAssemblyZone();
        }
    }

    public void RemoveFromAssemblyZone()
    {
        assemblyZoneCollider.gameObject.GetComponent<AssemblyZone>().RemoveBodyPart(type);
    }
}
