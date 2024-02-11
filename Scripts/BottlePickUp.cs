using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottlePickUp : MonoBehaviour
{

    private float bottlePickCooldown = 20;
    public static float nextBottlePickTime = 0;
    private float startTime;
    private float holdTime = 2;
    private bool onPickUpTrigger;
    private float bottleNumber;
    public static float bottleAmount;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (onPickUpTrigger == true)
        {
            if (BottleBag.bottlesInBag < BottleBag.maxBottlesInBag)
            {
                bottleCooldown();
                print(startTime);
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BottleSpot")
        {
            onPickUpTrigger = true;

        }
        if (other.gameObject.tag != "BottleSpot")
        {
            onPickUpTrigger = false;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bottle")
        {
            if (BottleBag.bottlesInBag < BottleBag.maxBottlesInBag)
            {
                Destroy(other.gameObject);
                BottleBag.bottlesInBag += 1;
            }

        }
    }

    void bottleCooldown()
    {
        if (Time.time > nextBottlePickTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                startTime = Time.time;

            }
            if (Input.GetKey(KeyCode.E) && startTime + holdTime <= Time.time)
            {

                bottleNumber = Random.Range(0, 100);
                if (bottleNumber <= 25 && bottleNumber >= 0)
                {

                    BottleBag.bottlesInBag += 1;
                    bottleAmount = 1;

                }
                if (bottleNumber >= 25 && bottleNumber <= 50)
                {

                    BottleBag.bottlesInBag += 2;
                    bottleAmount = 2;
                }
                if (bottleNumber >= 50 && bottleNumber <= 75)
                {

                    BottleBag.bottlesInBag += 3;
                    bottleAmount = 3;
                }
                if (bottleNumber >= 75 && bottleNumber <= 90)
                {

                    BottleBag.bottlesInBag += 4;
                    bottleAmount = 4;
                }
                if (bottleNumber >= 90 && bottleNumber <= 100)
                {
                    BottleBag.bottlesInBag += 5;
                    bottleAmount = 5;

                }
                if (bottleNumber == 69)
                {

                    BottleBag.bottlesInBag += 10;
                    bottleAmount = 10;
                }
                pickUpText.pickUpBottleText.gameObject.SetActive(true);
                pickUpText.pickUpBottleText.enabled = true;
                pickUpText.textStartTime = Time.time;
                pickUpText2.pickUpBottleText.gameObject.SetActive(true);
                pickUpText2.pickUpBottleText.enabled = true;
                pickUpText2.textStartTime = Time.time;
                nextBottlePickTime = Time.time + bottlePickCooldown;
            }

        }
    }

}