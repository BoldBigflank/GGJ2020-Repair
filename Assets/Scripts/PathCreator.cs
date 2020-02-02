using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    [SerializeField] int interpolationsBetweenPoints = 10; //Make this even or it might break
    List<Transform> nodes;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] bool drawSpline = false;
    private Vector3[] pathPositions;

    void Start()
    {
        nodes = new List<Transform>();
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        bool skipFirst = false; //First child transform will be path transfrom itself
        foreach (Transform node in GetComponentsInChildren<Transform>())
        {
            if (!skipFirst)  //This would be cleaner if it was an enum but oh well
            {
                skipFirst = true;
            }
            else
            {
                nodes.Add(node);
                node.GetComponent<MeshRenderer>().enabled = drawSpline;
            }
        }
        int totalInterpolations = nodes.Count * (interpolationsBetweenPoints / 2) - (interpolationsBetweenPoints / 2 - 1);
        lineRenderer.positionCount = totalInterpolations;
        pathPositions = new Vector3[totalInterpolations];
        lineRenderer.enabled = drawSpline;
        DrawCurve();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (drawSpline)
        {
            DrawCurve();
        }
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
            float t = (i % interpolationsBetweenPoints) / (float)interpolationsBetweenPoints;
            pathPositions[i] = CalculateBezierPoint(t, nodes[nodeCount].position, nodes[nodeCount + 1].position, nodes[nodeCount + 2].position);
        }
        pathPositions[pathPositions.Length - 1] = nodes[nodes.Count - 1].position;
        if (drawSpline)
        {
            lineRenderer.SetPositions(pathPositions);
        }
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

    public Vector3[] GetPathPositions()
    {
        return pathPositions;
    }
}
