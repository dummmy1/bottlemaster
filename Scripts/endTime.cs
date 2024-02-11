using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endTime : MonoBehaviour
{
    private Text endTimeText;

    public static string endTimeString;

    // Start is called before the first frame update
    void Start()
    {
        endTimeText = GetComponent<Text>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    // Update is called once per frame
    void Update()
    {
        

        endTimeText.text = "You finished in: " + endTimeString;
    }
}
