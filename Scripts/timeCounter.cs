using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeCounter : MonoBehaviour
{
    private Text timeCountText;
    
    public static string currentTime;

    // Start is called before the first frame update
    void Start()
    {
        timeCountText = GetComponent<Text>();
        

    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time.ToString("F3");

        timeCountText.text = "Time: " + currentTime;
    }
}
