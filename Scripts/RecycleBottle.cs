using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleBottle : MonoBehaviour
{

    private float bottleRecycleCooldown = 0.1f;
    private float nextBottleRecycleTime = 0.1f;
    private float startTime;
    private float holdTime = 3;
    private bool onRecycleTrigger;
    private float bottleCount;
    private float bottleAddResetTime = 3;
    private float bottleAddResetStartTime;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (onRecycleTrigger == true)
        {


            bottleCooldown();
            print(startTime);

        }

        bottleCount = BottleBag.bottlesInBag;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BottleRecycleSpot")
        {
            onRecycleTrigger = true;

        }
        if (other.gameObject.tag != "BottleRecycleSpot")
        {
            onRecycleTrigger = false;

        }

    }

    void bottleCooldown()
    {
        if (Time.time > nextBottleRecycleTime && BottleBag.bottlesInBag > 0)
        {
            if (bottleAddResetStartTime + bottleAddResetTime <= Time.time)
            {
                recycleSingleBottle.recycleAddAmount = 0;

            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                startTime = Time.time;
                bottleAddResetStartTime = Time.time;
            }
            if (Input.GetKeyUp(KeyCode.E) && BottleBag.bottlesInBag != 0)
            {

                MoneyBag.moneyInBag += 1;
                BottleBag.bottlesInBag -= 1;
                recycleSingleBottle.recycleSingleText.enabled = true;
                recycleSingleBottle.recycleSingleText.gameObject.SetActive(true);
                recycleSingleBottle.recycleSingleTextStartTime = Time.time;
                recycleSingleBottle.recycleAddAmount += 1;


            }

            if (Input.GetKey(KeyCode.E) && startTime + holdTime <= Time.time)
            {


                MoneyBag.moneyInBag += bottleCount;
                BottleBag.bottlesInBag -= bottleCount;
                nextBottleRecycleTime = Time.time + bottleRecycleCooldown;
                recycleText.recyclingText.gameObject.SetActive(true);
                recycleText.recyclingText.enabled = true;
                recycleText.recycleTextStartTime = Time.time;
            }

        }
    }
}
