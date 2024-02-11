using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottleBag : MonoBehaviour
{

    public static float bottlesInBag = 0;
    public static float maxBottlesInBag = 50;
    Text bottlesInBagText;
    // Start is called before the first frame update
    void Start()
    {
        bottlesInBagText = GetComponent<Text>();

        //reset bottle score
        bottlesInBag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bottlesInBagText.text = "BAG: " + bottlesInBag;
    }
}
