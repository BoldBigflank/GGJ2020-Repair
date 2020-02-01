using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] GameObject path;
    [SerializeField] float speed = 1f;
    [SerializeField] int interpolationsBetweenPoints = 10; //Make this even or it might break
    List<Transform> nodes;
    int nextPointNum;
    Vector3 nextPoint;
    [SerializeField] LineRenderer lineRenderer;
    private Vector3[] pathPositions;

    void Start()
    {
        nodes = new List<Transform>();
        bool skipFirst = false; //First child transform will be path transfrom itself
        foreach (Transform node in path.GetComponentsInChildren<Transform>())
        {
            if (!skipFirst)  //This would be cleaner if it was an enum but oh well
            {
                skipFirst = true;
            }
            else
            {
                nodes.Add(node);
            }
        }
        int totalInterpolations = nodes.Count * (interpolationsBetweenPoints / 2) - (interpolationsBetweenPoints / 2 - 1);
        lineRenderer.positionCount = totalInterpolations;
        pathPositions = new Vector3[totalInterpolations];
        DrawCurve();
        nextPointNum = 0;
        nextPoint = pathPositions[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        DrawCurve();
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

    private void DrawCurve()
    {
        int nodeCount = 0;
        for (int i = 0; i < pathPositions.Length - 1; i++)
        {
            if (i % interpolationsBetweenPoints == 0 && i != 0)
            {
                nodeCount += 2;
            }
            float t = (i % interpolationsBetweenPoints) / (float) interpolationsBetweenPoints;
            pathPositions[i] = CalculateBezierPoint(t, nodes[nodeCount].position, nodes[nodeCount + 1].position, nodes[nodeCount + 2].position);
        }
        pathPositions[pathPositions.Length - 1] = nodes[nodes.Count - 1].position;
        lineRenderer.SetPositions(pathPositions);
    }

    private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        return p;
    }
}
