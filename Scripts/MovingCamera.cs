using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    Vector3 origin;
    Vector3 target;
    float ratio = 0.01f;
    void Start()
    {
        origin = transform.position;
        InvokeRepeating("ChangeTarget", 0.01f, 10f);
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, ratio);
    }
    void ChangeTarget()
    {
        float x = Random.Range(-0.1f, 0.1f);
        float y = Random.Range(-0.1f, 0.1f);
        target = new Vector3(origin.x + x, origin.y + y, origin.z);
    }
}

