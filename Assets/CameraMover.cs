using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += Vector3.up * speed * Time.deltaTime;
        transform.eulerAngles += Vector3.forward * speed * Time.deltaTime;
    }
}
