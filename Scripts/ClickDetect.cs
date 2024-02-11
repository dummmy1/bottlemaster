using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickDetect : MonoBehaviour
{
    public int SceneToLoad;

    void OnMouseUp()
    {
        SceneManager.LoadScene(SceneToLoad);  
    }
}
