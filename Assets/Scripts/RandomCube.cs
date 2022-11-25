using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class RandomCube : MonoBehaviour
{
    public int detail;
    public float halfLength;
    public float difference;
    public float frameInterval;
    public List<Vector3> points = new List<Vector3>();
    public List<Vector3> randomPoints = new List<Vector3>();
    public List<int[]> faces = new List<int[]>();
    int randomPointsMax;
    MeshFilter meshFilter;
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        points.Add(Vector3.zero);
        points.Add(Vector3.left * halfLength + Vector3.up * halfLength + Vector3.forward * halfLength);
        points.Add(Vector3.right * halfLength + Vector3.up * halfLength + Vector3.forward * halfLength);
        points.Add(Vector3.right * halfLength + Vector3.down * halfLength + Vector3.forward * halfLength);
        points.Add(Vector3.left * halfLength + Vector3.down * halfLength + Vector3.forward * halfLength);
        points.Add(Vector3.left * halfLength + Vector3.up * halfLength + Vector3.back * halfLength);
        points.Add(Vector3.right * halfLength + Vector3.up * halfLength + Vector3.back * halfLength);
        points.Add(Vector3.right * halfLength + Vector3.down * halfLength + Vector3.back * halfLength);
        points.Add(Vector3.left * halfLength + Vector3.down * halfLength + Vector3.back * halfLength);
        faces.Add(new int[4] { 1, 2, 3, 4 }); //forward
        faces.Add(new int[4] { 6, 5, 8, 7 }); //back
        faces.Add(new int[4] { 2, 6, 7, 3 }); //right
        faces.Add(new int[4] { 5, 1, 4, 8 }); //left
        faces.Add(new int[4] { 4, 3, 7, 8 }); //down
        faces.Add(new int[4] { 5, 6, 2, 1 }); //up
        for (int i = 0; i < detail; i++)
        {
            var newFaces = new List<int[]>();
            randomPointsMax = points.Count;
            for (int f = 0; f < faces.Count; f++)
            {
                newFaces.AddRange(IncreaseQualityOfFace(faces[f]));
            }
            faces = newFaces;
        }
        MakeFrame();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void RandomPoints()
    {
        randomPoints = new List<Vector3>();
        for (int p = 0; p < points.Count; p++)
        {
            if (p < randomPointsMax)
            {
                randomPoints.Add(points[p] + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * difference);
            }
            else
            {
                randomPoints.Add(points[p]);
            }
        }
    }
    public List<int[]> IncreaseQualityOfFace(int[] face)
    {
        var upLeft = face[0];
        var upRight = face[1];
        var downRight = face[2];
        var downLeft = face[3];

        var left = AddPoint(Vector3.Lerp(points[face[0]], points[face[3]], 0.5f));
        var right = AddPoint(Vector3.Lerp(points[face[1]], points[face[2]], 0.5f));
        var up = AddPoint(Vector3.Lerp(points[face[0]], points[face[1]], 0.5f));
        var down = AddPoint(Vector3.Lerp(points[face[2]], points[face[3]], 0.5f));
        var center = AddPoint(Vector3.Lerp(points[left], points[right], 0.5f));

        var list = new List<int[]>();
        list.Add(new int[4] { upLeft, up, center, left });
        list.Add(new int[4] { up, upRight, right, center });
        list.Add(new int[4] { center, right, downRight, down });
        list.Add(new int[4] { left, center, down, downLeft });
        return list;
    }
    public int AddPoint(Vector3 p)
    {
        var index = points.IndexOf(p);
        if (index != -1)
        {
            return index;
        }
        else
        {
            points.Add(p);
            return points.Count - 1;
        }
    }
    public int CreateCenterIndex(int[] face, ref List<Vector3> pList)
    {
        pList.Add(0.25f * pList[face[0]] + 0.25f * pList[face[1]] + 0.25f * pList[face[2]] + 0.25f * pList[face[3]]);
        return pList.Count - 1;
    }
    public void CreateShape()
    {
        var mesh = new Mesh();
        mesh.Clear();
        List<int> triangles = new List<int>();

        List<Vector3> pList = new List<Vector3>(randomPoints);
        for (int f = 0; f < faces.Count; f++)
        {
            var center = CreateCenterIndex(faces[f], ref pList);
            triangles.Add(faces[f][0]);
            triangles.Add(faces[f][1]);
            triangles.Add(center);
            triangles.Add(faces[f][1]);
            triangles.Add(faces[f][2]);
            triangles.Add(center);
            triangles.Add(faces[f][2]);
            triangles.Add(faces[f][3]);
            triangles.Add(center);
            triangles.Add(faces[f][3]);
            triangles.Add(faces[f][0]);
            triangles.Add(center);
            /*triangles.Add(faces[f][2]);
            triangles.Add(faces[f][1]);
            triangles.Add(faces[f][0]);
            triangles.Add(faces[f][0]);
            triangles.Add(faces[f][3]);
            triangles.Add(faces[f][2]);*/
        }
        mesh.vertices = pList.ToArray();
        mesh.triangles = triangles.ToArray();
        meshFilter.mesh = mesh;

        
    }
    public void MakeFrame()
    {
        RandomPoints();
        CreateShape();
        Invoke(nameof(MakeFrame), frameInterval);
    }
}
