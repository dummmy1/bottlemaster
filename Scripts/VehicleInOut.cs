using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleInOut : MonoBehaviour
{
    public GameObject vehicle;
    public GameObject vehicleCamera;
    public GameObject player;
    public GameObject playerMesh;
    public GameObject playerMeshHands;
    public GameObject playerCamera;
    public GameObject carTrigger;
    public GameObject carDriveSpot;
    public bool carTriggerBool;
    public bool inCar;

    private void Start()
    {
        vehicle.GetComponent<CarController>().enabled = false;
        vehicle.GetComponent<Drivetrain>().enabled = false;
        vehicle.GetComponent<SoundController>().enabled = false;
        vehicleCamera.SetActive(false);
        player.SetActive(true);
        player.GetComponent<MeshRenderer>().enabled = true;

        playerCamera.SetActive(true);
        inCar = false;
    }

    private void Update()
    {
        if (!inCar && carTriggerBool)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                vehicle.GetComponent<CarController>().enabled = true;
                vehicle.GetComponent<Drivetrain>().enabled = true;
                vehicle.GetComponent<SoundController>().enabled = true;
                vehicleCamera.SetActive(true);
                player.GetComponent<MeshRenderer>().enabled = false;
                player.GetComponent<StrafeMovement>().enabled = false;
                playerCamera.SetActive(false);
                inCar = true;
                player.transform.position = carDriveSpot.transform.position;
                carTriggerBool = false;
            }
        }

        if (inCar)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                vehicle.GetComponent<CarController>().enabled = false;
                vehicle.GetComponent<Drivetrain>().enabled = false;
                vehicle.GetComponent<SoundController>().enabled = false;
                vehicleCamera.SetActive(false);
                player.GetComponent<MeshRenderer>().enabled = true;
                player.GetComponent<StrafeMovement>().enabled = true;
                playerCamera.SetActive(true);
                inCar = false;
                player.transform.position = carTrigger.transform.position;
                carTriggerBool = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "carTrigger")
        {
            carTriggerBool = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "carTrigger")
        {
            carTriggerBool = false;
        }

    }
}
