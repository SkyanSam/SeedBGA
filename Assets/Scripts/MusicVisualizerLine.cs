using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVisualizerLine : MonoBehaviour
{
    LineRenderer lineRenderer;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Update()
    {
        lineRenderer.positionCount = MusicVisualizer.samples.Length / 3;
        for (int i = 0; i < MusicVisualizer.samples.Length / 3; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(i / (float)(MusicVisualizer.samples.Length/3), MusicVisualizer.samples[i], 0));
        }
    }
}
