using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchWeapon : MonoBehaviour
{
    public GameObject rocketLauncher;
    public GameObject canLauncher;
    public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        canLauncher.SetActive(true);
        rocketLauncher.SetActive(false);
        hand.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(RocketBuyingSpot.rocketBuy == true)
            {
                rocketLauncher.SetActive(true);
                canLauncher.SetActive(false);
                hand.SetActive(false);
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            canLauncher.SetActive(true);
            rocketLauncher.SetActive(false);
            hand.SetActive(true);
        }
    }
}
