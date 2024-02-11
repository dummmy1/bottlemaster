using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBuyingSpot : MonoBehaviour
{
    private bool onBuyTrigger;
    public static bool rocketBuy;
    public float rocketPrice = 50;

    // Start is called before the first frame update
    void Start()
    {
        rocketBuy = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (onBuyTrigger && !rocketBuy)
        {
            buyRocket();
        }


        if (!rocketBuy)
        {
            GameObject shootCamera = GameObject.Find("PlayerCamera");
            shootCamera.GetComponent<ShootProjectile>().enabled = false;
        }
        if (rocketBuy)
        {
            GameObject shootCamera = GameObject.Find("PlayerCamera");
            shootCamera.GetComponent<ShootProjectile>().enabled = true;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BuyTrigger")
        {
            onBuyTrigger = true;

        }
        if (other.gameObject.tag != "BuyTrigger")
        {
            onBuyTrigger = false;

        }
    }

    void buyRocket()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (MoneyBag.moneyInBag >= 50)
            {
                MoneyBag.moneyInBag -= rocketPrice;
                rocketBuy = true;

            }


        }
    }
}