using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagment : MonoBehaviour
{
    public int SceneToLoad;

    public void LevelLoader()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}

