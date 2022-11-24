using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedRandom
{
    public static float max = 0.5f;
    public static int inCount = 0;
    public static int outCount = 0;
    public static float NextGaussian()
    {
        float v1, v2, s;
        do
        {
            v1 = 2.0f * Random.Range(0f, 1f) - 1.0f;
            v2 = 2.0f * Random.Range(0f, 1f) - 1.0f;
            s = v1 * v1 + v2 * v2;
        } while (s >= 1.0f || s == 0f);
        s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);

        if (Mathf.Abs(v1 * s) > 1) outCount++;
        else inCount++;
        UnityEngine.Debug.Log($"In{inCount}/Out{outCount}");
        
        return Mathf.Max(Mathf.Min(v1 * s, max), -max) / max;
    }
    public static float ReverseGaussian()
    {
        return NextGaussian();
        var g = NextGaussian();
        var a = g / Mathf.Abs(g);
        return a * (1 - Mathf.Abs(g));
    }
}
