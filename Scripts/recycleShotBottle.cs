using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recycleShotBottle : MonoBehaviour
{
    private float radius = 5;
    private float force = 5;

    private Collider[] hitColliders;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

        DoExplosion(collision.contacts[0].point);
        Destroy(gameObject, 1);
    }

    void DoExplosion(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, radius);
        foreach (Collider hitcol in hitColliders)
        {
            if (hitcol.gameObject.tag == "RecycleMachine")
            {
                hitcol.GetComponent<Rigidbody>().isKinematic = false;
                MoneyBag.moneyInBag += 1;
                Destroy(gameObject);
            }

        }

    }
}
