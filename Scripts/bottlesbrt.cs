using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottlesbrt : MonoBehaviour
{
    private float speed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        float x = UnityEngine.Random.Range(-2, 2);
        float y = UnityEngine.Random.Range(-2, 2);

        GetComponent<Rigidbody>().velocity = new Vector3(speed * x, speed * y, 0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
