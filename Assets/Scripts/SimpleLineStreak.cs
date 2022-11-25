using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLineStreak : MonoBehaviour
{
    public float halfWidth;
    public float halfHeight;
    public float halfDepth;
    public float streakLength;
    public float speed;
    LineRenderer lineRenderer;
    Vector3[] points = new Vector3[2];
    Vector3 coordinate;
    Vector3 start;
    Vector3 target;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        coordinate = new Vector3(Random.Range(-halfWidth, halfWidth), Random.Range(-halfHeight, halfHeight), 0);
        target = coordinate + Vector3.back * halfDepth;
        start = coordinate + Vector3.forward * halfDepth;
        points[0] = points[1] = start;
        lineRenderer.startColor = lineRenderer.endColor = GetRandomColor();
    }

    bool isPastMagnitude;
    void Update()
    {
        points[0] = Vector3.MoveTowards(points[0], target, speed * Time.deltaTime);
        if ((points[0] - points[1]).magnitude >= streakLength && points[1] == start)
        {
            isPastMagnitude = true;
        }
        if (isPastMagnitude)
        {
            points[1] = Vector3.MoveTowards(points[1], target, speed * Time.deltaTime);
        }
        if (points[0] == points[1] && points[0] == target)
        {
            Destroy(gameObject);
        }
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(points);
        lineRenderer.enabled = true;
    }
    Color GetRandomColor()
    {
        return Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
    }
}
