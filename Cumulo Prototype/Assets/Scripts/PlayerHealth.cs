using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Transform spawning;
    public GameObject player;
    public float maxHealth = 100;
    private float currentHealth;
    public Slider healthBar;
    public float damageToPlayer = 25;
    
    
    // Start is called before the first frame update


    

    void Start()
    {
        
        ResetHealth();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DealDamage();
            CalculateHealth();
            healthBar.value = CalculateHealth();
        }

        if (currentHealth <= 0)
        {
            
            player.GetComponent<CharacterMovement>().PlayerDeath();
            ResetHealth();
            healthBar.value = CalculateHealth();
            Debug.Log("Player was Killed");
        }
    }

    private void DealDamage()
    {
        currentHealth -= damageToPlayer;
    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

    private void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    
}
