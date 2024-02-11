using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickQuit : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseUp()
    {
        Application.Quit();
    }
}
