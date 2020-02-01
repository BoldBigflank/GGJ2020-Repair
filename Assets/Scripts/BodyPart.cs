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
}
