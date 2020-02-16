using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AssemblyZone : MonoBehaviour
{
    public class PlacementPoint
    {
        private Transform pointTransform = null;
        private BodyPart bodyPart = null;
        private GameObject assemblyZoneObject;

        public PlacementPoint(Transform pos)
        {
            pointTransform = pos;
            assemblyZoneObject = pointTransform.parent.gameObject;
        }

        public Transform GetPointTransform()
        {
            return pointTransform;
        }

        public GameObject GetAssemblyZone()
        {
            return assemblyZoneObject;
        }

        public void SetBodyPart(BodyPart bodyPart)
        {
            this.bodyPart = bodyPart;
        }

        public BodyPart GetBodyPart()
        {
            return bodyPart;
        }

        public bool IsSpotOccupied()
        {
            return bodyPart != null;
        }
    }

    private PlacementPoint[] legPoints;
    private PlacementPoint headPoint;
    [SerializeField] float maxDistance = 52.0f;

    void Start()
    {
        legPoints = new PlacementPoint[4];
        for (int i = 0; i < 4; i++)
        {
            legPoints[i] = new PlacementPoint(transform.GetChild(i));
        }
        headPoint = new PlacementPoint(transform.GetChild(4));
    }

    public LinkedList<BodyPart> GetBodyParts()
    {
        LinkedList <BodyPart> bodyParts = new LinkedList<BodyPart>();
        for (int i = 0; i < 4; i++)
        {
            if (legPoints[i].IsSpotOccupied())
            {
                bodyParts.AddLast(legPoints[i].GetBodyPart());
            }
        }
        if (headPoint.IsSpotOccupied())
        {
            bodyParts.AddLast(headPoint.GetBodyPart());
        }
        return bodyParts;
    }

    //Called by the player controller when they drop off a body part
    //Returns point it is placed at, null if not placed
    public PlacementPoint DropOffBodyPart(BodyPart bodyPart)
    {
        float closestDistance = 10000.0f; //Arbitrarily large number
        PlacementPoint closestPoint = null;
        float currentDistance;

        if (bodyPart.type == BodyPartTypes.Feet) {
            for (int i = 0; i < 4; i++)
            {
                if (!legPoints[i].IsSpotOccupied())
                {
                    currentDistance = Vector3.Distance(bodyPart.transform.position, legPoints[i].GetPointTransform().position);
                    if (currentDistance < closestDistance)
                    {
                        closestPoint = legPoints[i];
                        closestDistance = currentDistance;
                    }
                }
            }
        }
        else
        {
            if (!headPoint.IsSpotOccupied())
            {
                currentDistance = Vector3.Distance(bodyPart.transform.position, headPoint.GetPointTransform().position);
                if (currentDistance < closestDistance)
                {
                    closestPoint = headPoint;
                    closestDistance = currentDistance;
                }
            }
        }

        if(closestDistance < maxDistance)
        {
            bodyPart.transform.SetParent(closestPoint.GetPointTransform());
            bodyPart.transform.localPosition = Vector3.zero;
            closestPoint.SetBodyPart(bodyPart);

            return closestPoint;
        }
        return null;
    }

    public bool HasLessThanOneHead()
    {
        return !headPoint.IsSpotOccupied();
    }

    public bool HasLessThanFourLimbs()
    {
        foreach (PlacementPoint placementPoint in legPoints)
        {
            if (!placementPoint.IsSpotOccupied())
            {
                return true;
            }
        }
        return false;
    }
}
