using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMeter : MonoBehaviour
{
    public float maxMeter = 100;
    public float currentMeter;
    public Slider meter;
    public float addMeter = 25;
    
    // Start is called before the first frame update
    void Start()
    {
        currentMeter = 0;
        meter.value = currentMeter;
    }

    // Update is called once per frame
    void Update()
    {
        //If you hold down s and any of the movement inputs; add to meter
        if (Input.GetKey("s") && Input.GetKey("d") || Input.GetKey("s") && Input.GetKey("right") || Input.GetKey("s") && Input.GetKey("a") || Input.GetKey("s") && Input.GetKey("left"))
        {
            AddMeter();
            CalculateMeter();
            meter.value = CalculateMeter();
            
            Debug.Log("Filling Meter");
        }

        if(currentMeter >= maxMeter)
        {
            currentMeter = maxMeter;
            meter.value = currentMeter;

            Debug.Log("Meter Is Maxed");
        }
    }
    private void AddMeter()
    {
        currentMeter += addMeter * Time.deltaTime;
    }

    public float CalculateMeter()
    {
        return currentMeter / maxMeter;
    }
}
