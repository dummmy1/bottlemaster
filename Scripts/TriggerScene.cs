using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScene : MonoBehaviour
{
    public int SceneToLoad;
    public void OnTriggerStay(Collider other)
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
