using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityLightning : MonoBehaviour
{
    public Transform spawnLocation;
    public GameObject projectilePF;
    
    public Slider meter;
    
    

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
            meter.value = 0;
        }
    }

    private void ShootProjectile()
    {
        Instantiate(projectilePF, spawnLocation.position, spawnLocation.rotation);
    }
    
}

