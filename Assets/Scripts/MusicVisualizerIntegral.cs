using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVisualizerIntegral : MonoBehaviour
{
    public TMPro.TextMeshPro textMesh;
    string prevText;
    private void Start()
    {
        prevText = textMesh.text;
    }
    void Update()
    {
        textMesh.text = prevText + $"f(x)dx = {Round(ComputeIntegral() * 100, 2)}";
    }
    float ComputeIntegral()
    {
        float integral = 0.0f;
        for (int i = 0; i < MusicVisualizer.samples.Length; i++)
        {
            integral += (float)MusicVisualizer.samples[i] / MusicVisualizer.samples.Length;
        }
        return integral;
    }
    float Round(float num, int decimalPlace)
    {
        return Mathf.Round(num * Mathf.Pow(10, decimalPlace)) / Mathf.Pow(10, decimalPlace);
    }
}
