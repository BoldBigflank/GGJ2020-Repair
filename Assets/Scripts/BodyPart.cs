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
    
    
    [SerializeField]
    public bool isHead = false;
    [SerializeField]
    public bool isRightLimb = false;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;
        //gameObject.GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);
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
