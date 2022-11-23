using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public int number;
    public GameObject obj;
    void Start()
    {
        for (int i = 0; i < number; i++) Instantiate(obj);
    }
}
