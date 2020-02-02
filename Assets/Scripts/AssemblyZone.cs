using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AssemblyZone : MonoBehaviour
{
    public class PlacementPoint
    {
        public PlacementPoint(Transform pos)
        {
            pointTransform = pos;
        } 

        public Transform pointTransform = null;
        public bool positionOcupied = false;
    }

    public PlacementPoint position1;
    public PlacementPoint position2;
    public PlacementPoint position3;
    public PlacementPoint position4;
    public PlacementPoint position5;
    public LinkedList<BodyPart> bodyParts;

    private float maxDistance = 52.0f;


    // Start is called before the first frame update
    void Start()
    {
        bodyParts = new LinkedList<BodyPart>();

        position1 = new PlacementPoint(transform.GetChild(0));
        position2 = new PlacementPoint(transform.GetChild(1));
        position3 = new PlacementPoint(transform.GetChild(2));
        position4 = new PlacementPoint(transform.GetChild(3));
        position5 = new PlacementPoint(transform.GetChild(4));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called by the player controller when they drop off a body part
    public bool DropOffBodyPart(BodyPart bodyPart)
    {
        return FindHomeForBodyPart(bodyPart);
    }

    public void RemoveBodyPart(BodyPart bodyPart)
    {
        PlacementPoint temp = bodyPart.GetPlacementPoint();
        temp.positionOcupied = false;
        bodyPart.transform.SetParent(null);
        bodyParts.Remove(bodyPart);
    }

    public LinkedList<BodyPart> GetBodyParts()
    {
        return bodyParts;
    }

    public bool FindHomeForBodyPart(BodyPart bodyPart)
    {
        float closestDistance = 10000.0f; //Arbitrarily large number
        PlacementPoint closestPoint = null;
        float currentDistance;
        bool succesFlag = false;

        if(!position1.positionOcupied)
        {
            //Debug.Log("Position1 is not occupied?");
            currentDistance = Vector3.Distance(bodyPart.transform.position, position1.pointTransform.position);
            //Debug.Log("Position1: " + currentDistance);
            if(currentDistance < closestDistance)
            {
                closestPoint = position1;
                closestDistance = currentDistance;
            }
        }

        if(!position2.positionOcupied)
        {
            currentDistance = Vector3.Distance(bodyPart.transform.position, position2.pointTransform.position);
            //Debug.Log("Position2: " + currentDistance);
            if(currentDistance < closestDistance)
            {
                closestPoint = position2;
                closestDistance = currentDistance;
            }
        }

        if(!position3.positionOcupied)
        {
            currentDistance = Vector3.Distance(bodyPart.transform.position, position3.pointTransform.position);
            //Debug.Log("Position3: " + currentDistance);
            if(currentDistance < closestDistance)
            {
                closestPoint = position3;
                closestDistance = currentDistance;
            }  
        }

        if(!position4.positionOcupied)
        {
            currentDistance = Vector3.Distance(bodyPart.transform.position, position4.pointTransform.position);
            //Debug.Log("Position4: " + currentDistance);
            if(currentDistance < closestDistance)
            {
                closestPoint = position4;
                closestDistance = currentDistance;
            }
        }

        if(!position5.positionOcupied)
        {
            currentDistance = Vector3.Distance(bodyPart.transform.position, position5.pointTransform.position);
            //Debug.Log("Position5: " + currentDistance);
            if(currentDistance < closestDistance)
            {
                closestPoint = position5;
                closestDistance = currentDistance;
            }
        }

        
        if(closestDistance < maxDistance)
        {
            bodyPart.transform.SetParent(this.transform);
            bodyPart.transform.position = closestPoint.pointTransform.position;
            closestPoint.positionOcupied = true;
            bodyParts.AddFirst(bodyPart);
            succesFlag = true;
            bodyPart.AssignPlacementPoint(closestPoint);
        }

        //Debug.Log(closestDistance);
        //Debug.Log(maxDistance);

        return succesFlag;
    }
}
