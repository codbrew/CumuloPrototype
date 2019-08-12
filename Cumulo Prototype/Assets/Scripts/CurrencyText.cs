using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyText : MonoBehaviour
{
    TextMeshProUGUI text;
    public static int currencyValue;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Currency: " + currencyValue.ToString();
    }
}
