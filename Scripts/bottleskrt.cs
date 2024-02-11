using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleskrt : MonoBehaviour
{
    private float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        float x = UnityEngine.Random.Range(-1, 1);
        float y = UnityEngine.Random.Range(-1, 1);

        GetComponent<Rigidbody>().velocity = new Vector3(speed * x, speed * y, 0f);
    }

    // Update is called once per frame
    void Update()
    {

    }


}