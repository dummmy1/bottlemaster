using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buyEnd : MonoBehaviour
{
    public int SceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "buyEnd")
        {
            if (Input.GetKeyDown(KeyCode.E) && MoneyBag.moneyInBag >= 200)
            {
                SceneManager.LoadScene(SceneToLoad);
                endTime.endTimeString = timeCounter.currentTime;
            }
        }
    }
}
