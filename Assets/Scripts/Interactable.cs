using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Collider2D assemblyZoneCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "AssemblyZone")
        {
            //Debug.Log("Interactable has entered pickup zone");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "AssemblyZone")
        {
            //Debug.Log("Interactable has exited pickup zone");
        }
    }

    public void PickedUpByPlayer()
    {
        //Debug.Log("Someone picked me up!");
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void DroppedByPlayer()
    {
        //Debug.Log("Someone dropped me! :(");
        //gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
