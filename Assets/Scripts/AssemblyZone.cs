using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropOffInteractable(Collider2D col)
    {
        Debug.Log("A player gave the assembly zone an interactable");
    }
}
