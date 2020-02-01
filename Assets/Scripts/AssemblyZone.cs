using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyZone : MonoBehaviour
{
    public BodyPart head;
    public BodyPart torso;
    public BodyPart feet;
    private BodyPart tempBodyPart;

    [SerializeField]
    private Transform headTransform;
    [SerializeField]
    private Transform torsoTransform;
    [SerializeField]
    private Transform feetTransform;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called by the player controller when they drop off a body part
    public void DropOffBodyPart(Collider2D col)
    {
        tempBodyPart = col.GetComponent<BodyPart>();
        switch(tempBodyPart.type)
        {
            case BodyPartTypes.Head:
                head = tempBodyPart;
                tempBodyPart.transform.position = headTransform.position;
                break;

            case BodyPartTypes.Torso:
                torso = tempBodyPart;
                tempBodyPart.transform.position = torsoTransform.position;
                break;

            case BodyPartTypes.Feet:
                feet = tempBodyPart;
                tempBodyPart.transform.position = feetTransform.position;
                break;

            default:
                Debug.Log("BAD BODY PART BEING GIVEN TO ASSEMBLY ZONE");
                break;
        }
    }

    public void RemoveBodyPart(BodyPartTypes bodyPartType)
    {
        switch(bodyPartType)
        {
            case BodyPartTypes.Head:
                head = null;
                break;

            case BodyPartTypes.Torso:
                torso = null;
                break;

            case BodyPartTypes.Feet:
                feet = null;
                break;

            default:
                Debug.Log("BAD BODY PART BEING REMOVED FROM ASSEMBLY ZONE");
                break;
        }
    }
}
