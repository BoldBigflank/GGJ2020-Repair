using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    int nextPointNum;
    Vector3 nextPoint;
    Vector3[] pathPositions;

    void Start()
    {
        pathPositions = GameObject.FindGameObjectWithTag("Assembly Path").GetComponent<PathCreator>().GetPathPositions();
        nextPointNum = 0;
        nextPoint = pathPositions[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, nextPoint) < .05f)
        {
            nextPointNum++;
            if (nextPointNum >= pathPositions.Length)
            {
                nextPointNum = 0;
            }
            nextPoint = pathPositions[nextPointNum];
        }
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, nextPoint, step);
    }

}
