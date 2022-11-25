using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedRandomController : MonoBehaviour
{
    public float max = 0.5f;
    void Update()
    {
        AdvancedRandom.max = max;
    }
}
