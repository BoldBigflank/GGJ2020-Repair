using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelepotationVolumeScript : MonoBehaviour
{
    public Transform teleporationPoint;
    private Vector2 teleporationVector;


    void Start()
    {
        teleporationVector = new Vector2(teleporationPoint.position.x, teleporationPoint.position.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().Teleport(teleporationVector);
        }
    }
}
