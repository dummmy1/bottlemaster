using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    [SerializeField] private Light sun;
    [SerializeField] private float secondsInFullDay = 500f;
    [SerializeField] private GameObject storeDoor;

    [Range(0, 1)] [SerializeField] private float currentTimeOfDay = 0;
    private float timeMultiplier = 1f;
    private float sunInitialIntensity;

    public GameObject uiObject;
    public GameObject player;
    public GameObject npc;
    public Transform teleportTarget;

    public void Start()
    {
        //Needed to make everything work
        uiObject.SetActive(false);
        sunInitialIntensity = sun.intensity;
        player = GameObject.Find("Player");
        npc = GameObject.Find("NPC");
        storeDoor = GameObject.Find("Door");
        storeDoor.SetActive(true);
    }
    //Controls sun rotation
    public void Update()
    {
        UpdateSun();
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
        if (currentTimeOfDay < 0.23 || currentTimeOfDay > 0.75)
        {
            npc.SetActive(false);
            storeDoor.SetActive(true);
        }
        else if (currentTimeOfDay > 0.23 || currentTimeOfDay < 0.75)
        {
            npc.SetActive(true);
            storeDoor.SetActive(false);
        }
        void UpdateSun()
        {
            sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
            float intesityMultiplier = 1;

            if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
            {
                intesityMultiplier = 0;
            }
            else if (currentTimeOfDay <= 0.25f)
            {
                intesityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
            }
            else if (currentTimeOfDay >= 0.73f)
            {
                intesityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
            }
            sun.intensity = sunInitialIntensity * intesityMultiplier;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        //Prevents player for being in store during night.
        if (currentTimeOfDay < 0.23 || currentTimeOfDay > 0.75)
        {
            other.transform.position = teleportTarget.transform.position;
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    //Removes the text
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        uiObject.SetActive(false);
    }
}
