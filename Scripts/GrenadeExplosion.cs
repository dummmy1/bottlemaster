using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    public AudioSource ExpSound;
    public ParticleSystem effect;
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
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody>().detectCollisions = false;
        ExpSound.Play();
        effect.Play();
        DoExplosion(collision.contacts[0].point);
    }

    void DoExplosion(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, radius);
        foreach (Collider hitcol in hitColliders)
        {
            if (hitcol.GetComponent<Rigidbody>() != null)
            {
                
                hitcol.GetComponent<Rigidbody>().isKinematic = false;
                hitcol.GetComponent<Rigidbody>().AddExplosionForce(force, explosionPoint, radius, 1, ForceMode.Impulse);
                //Destroy(gameObject);
            }

        }

    }
}