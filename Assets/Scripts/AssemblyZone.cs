using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyZone : MonoBehaviour
{
    public LinkedList<BodyPart> bodyParts;


    // Start is called before the first frame update
    void Start()
    {
        bodyParts = new LinkedList<BodyPart>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called by the player controller when they drop off a body part
    public void DropOffBodyPart(BodyPart bodyPart)
    {
        bodyParts.AddFirst(bodyPart);
    }

    public void RemoveBodyPart(BodyPart bodyPart)
    {
        bodyParts.Remove(bodyPart);
    }
}
