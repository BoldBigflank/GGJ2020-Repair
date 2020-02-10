using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationVolumeScript : MonoBehaviour
{
    private Transform teleportationPoint;
    private Vector2 teleporationVector;
    [SerializeField] bool sidePortal;   //True if left/right, false if up/down

    void Start()
    {
        teleportationPoint = transform.GetChild(0);
        teleporationVector = new Vector2(teleportationPoint.position.x, teleportationPoint.position.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().Teleport(teleporationVector, sidePortal);
        }
    }

}
