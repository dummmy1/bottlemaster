using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    private float grenadeShootCooldown = 1.1f;
    public float nextShootTime = 0;
    public GameObject grenadePrefab;
    private float propulsionForce = 35;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextShootTime)
        {
            SpawnGrenade();
            nextShootTime = Time.time + grenadeShootCooldown;
        }
    }

    void SpawnGrenade()
    {
        GameObject grenade = (GameObject)Instantiate(grenadePrefab, transform.TransformPoint(0, 0, 2), transform.rotation);
        grenade.GetComponent<Rigidbody>().AddForce(transform.forward * propulsionForce, ForceMode.Impulse);

    }

}