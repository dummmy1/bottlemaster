using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChangeSpot : MonoBehaviour
{
    Renderer rend;
    public Material red;
    public Material blue;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > BottlePickUp.nextBottlePickTime)
        {
            gameObject.GetComponent<Renderer>().material = blue;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = red;
        }
    }
    
}