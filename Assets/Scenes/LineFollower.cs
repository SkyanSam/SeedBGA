using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFollower : MonoBehaviour
{
    public float radius = 50;
    public float speed = 100;
    public float minSegmentLength = 25;
    List<Vector3> points = new List<Vector3>();
    LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = lineRenderer.endColor = GetRandomColor();
        points.Add(GetRandomVector());
        points.Add(GetNextSegmentPoint());
        points.Add(new Vector3(points[1].x , points[1].y, points[1].z));
        points.Add(GetNextSegmentPoint());
    }

    // Update is called once per frame
    void Update()
    {
        points[0] = Vector3.MoveTowards(points[0], points[1], speed * Time.deltaTime);
        points[points.Count - 2] = Vector3.MoveTowards(points[points.Count - 2], points[points.Count - 1], speed * Time.deltaTime);

        if (points[0] == points[1])
            points.RemoveAt(0);

        if (points[points.Count - 2] == points[points.Count - 1])
            points.Add(GetNextSegmentPoint());

        var pointsMod = new List<Vector3>(points);
        pointsMod.RemoveAt(pointsMod.Count - 1);
        lineRenderer.positionCount = pointsMod.Count;
        lineRenderer.SetPositions(pointsMod.ToArray());
    }
    Vector3 GetRandomVector()
    {
        return new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), Random.Range(-radius, radius));
    }
    Vector3 GetNextSegmentPoint()
    {
        var rand = GetRandomVector();
        if ((rand - points[points.Count - 1]).magnitude >= minSegmentLength) return rand;
        else return GetNextSegmentPoint();
    }
    Color GetRandomColor()
    {
        return Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
    }
}
