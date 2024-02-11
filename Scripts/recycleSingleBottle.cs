using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recycleSingleBottle : MonoBehaviour
{
    public static Text recycleSingleText;
    public static float recycleSingleTextStartTime;
    public static float recycleSingleTextEndTime = 2;
    public static float recycleAddAmount;
    // Start is called before the first frame update
    void Start()
    {
        recycleSingleText = GetComponent<Text>();
        recycleSingleText.gameObject.SetActive(false);
        recycleSingleText.enabled = false;
        recycleAddAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (recycleSingleText.enabled == true)
        {
            recycleSingleText.text = "Recycled " + recycleAddAmount + " bottle(s)";


            if (recycleSingleTextStartTime + recycleSingleTextEndTime <= Time.time)
            {
                recycleSingleText.enabled = false;
                recycleSingleText.gameObject.SetActive(false);
            }
        }
    }
}