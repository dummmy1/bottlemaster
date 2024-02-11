using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBag : MonoBehaviour
{

    public static float moneyInBag = 49;
    Text moneyInBagText;
    // Start is called before the first frame update
    void Start()
    {
        moneyInBagText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyInBagText.text = "CASH: " + moneyInBag;
    }
}
