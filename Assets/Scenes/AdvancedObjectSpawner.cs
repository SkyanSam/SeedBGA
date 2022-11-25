using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedObjectSpawner : MonoBehaviour
{
    public GameObject obj;
    public float cooldown;
    float timer = 0;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            var e = Instantiate(obj);
            e.transform.SetParent(transform);
            timer = cooldown;
        }
    }
}
