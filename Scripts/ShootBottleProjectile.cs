using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBottleProjectile : MonoBehaviour
{
    private float bottleShootCooldown = 0.1f;
    public float nextShootTime;
    public GameObject bottlePrefab;
    private float propulsionForce = 50;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(BottleBag.bottlesInBag != 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextShootTime)
            {
                SpawnBottle();
                nextShootTime = Time.time + bottleShootCooldown;
            }
        }

    }

    void SpawnBottle()
    {
        GameObject bottle = (GameObject)Instantiate(bottlePrefab, transform.TransformPoint(0, 0, 2), transform.rotation);
        bottle.GetComponent<Rigidbody>().AddForce(transform.forward * propulsionForce, ForceMode.Impulse);
        BottleBag.bottlesInBag -= 1;
        

    }
}
