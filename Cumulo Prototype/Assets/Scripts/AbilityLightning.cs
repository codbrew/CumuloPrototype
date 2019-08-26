using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityLightning : MonoBehaviour
{
    public Transform spawnLocation;
    public GameObject projectilePF;
    
    public GameObject player;
    public Slider meter;
    public float decreaseMeter = 0.5f;
    
    

    // Start is called before the first frame update
    void Start()
    {
       
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f") && meter.value > 0.1)
        {
           
            ShootProjectile();
            player.GetComponent<PlayerMeter>().currentMeter -= decreaseMeter * Time.deltaTime;
            player.GetComponent<PlayerMeter>().meter.value -= decreaseMeter * Time.deltaTime;
        }

    }

    private void ShootProjectile()
    {
        Instantiate(projectilePF, spawnLocation.position, spawnLocation.rotation);
    }
    
}

