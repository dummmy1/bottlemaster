using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketSpotColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (RocketBuyingSpot.rocketBuy)
        {
            GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
    }
}