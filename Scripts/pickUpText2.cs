using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickUpText2 : MonoBehaviour
{
    public static Text pickUpBottleText;
    public static float textStartTime;
    public static float textEndTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        pickUpBottleText = GetComponent<Text>();
        pickUpBottleText.gameObject.SetActive(false);
        pickUpBottleText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpBottleText.enabled == true)
        {
            pickUpBottleText.text = "+" + BottlePickUp.bottleAmount;


            if (textStartTime + textEndTime <= Time.time)
            {
                pickUpBottleText.enabled = false;
                pickUpBottleText.gameObject.SetActive(false);
            }
        }
    }
}

