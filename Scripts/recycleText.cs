using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recycleText : MonoBehaviour
{
    public static Text recyclingText;
    public static float recycleTextStartTime;
    public static float recycleTextEndTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        recyclingText = GetComponent<Text>();
        recyclingText.gameObject.SetActive(false);
        recyclingText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (recyclingText.enabled == true)
        {
            recyclingText.text = "Recycled all bottles!";


            if (recycleTextStartTime + recycleTextEndTime <= Time.time)
            {
                recyclingText.enabled = false;
                recyclingText.gameObject.SetActive(false);
            }
        }
    }
}