using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    //Physics Variables
    //public float fallMultiplyer = 2.5f;
    //public float lowJumpMultiplier = 2f;

    //Currency Variables
    public int points = 0;

    //Player Variables Main
    public GameObject player;
    public Rigidbody rb;
    public float fwdMvSpeed = 2f;
    public float bckMvSpeed = -2f;
    public float jumpHeight = 2f;

    //Jumping Variables
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    //tunnel exit variables
    public Transform spawning;
    public Transform moveTo;
    public float moveSpeed = 1.0f;
    public float startTime;
    private float distance;
    public  float movementTimer = 0;
    public float addedGravity = 2f;
    

    //Access to Projectile Spawn
    public Transform projectileSpawn;

    //Rotation Values
    private bool facingRight = true;

    //Ground Check
    public Transform groundCheck;
    private bool isGrounded;

    //Game Manager
    public GameManager gameManager;

    
    

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        distance = Vector3.Distance(spawning.position, moveTo.position);
        
        
    
        
        
    }

    // Update is called once per frame
    void Update()
    {

      


        CountUp();
        
        
        if (movementTimer >= .1 && movementTimer <= 1)
        {
            TunnelExit();
        }
        else
        {
            PlayerControls();
        }

       
       
        
        
        
        
       
    }

    //Timer Count Up
    private void CountUp()
    {
        movementTimer += 1 * Time.deltaTime;
    }
    //player Controls
    private void PlayerControls() {

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity = new Vector2(fwdMvSpeed, rb.velocity.y);
            

            //Debug.Log("forward");
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            
            rb.velocity = new Vector2(bckMvSpeed, rb.velocity.y);
            
        
            //Debug.Log("Backward");
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); //stops character //find a new way to slow down character instead
        }

        //Rotate Player

        if (Input.GetKeyDown("d") && !facingRight || Input.GetKeyDown("right") && !facingRight)
        {
            FlipPlayer();
            //Debug.Log("Player Flipped Forward");
        } 
        if(Input.GetKeyDown("a") && facingRight || Input.GetKeyDown("left") && facingRight)
        {
            FlipPlayer();
            //Debug.Log("Player Flipped Backward");
        }


        //jump


        if (Input.GetKeyDown("space") && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

            if (jumpTimeCounter > 0 && isJumping == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                Debug.Log("jump");
                jumpTimeCounter -= Time.deltaTime;
            

        }
            else
            {
                isJumping = false;
            }

        if (Input.GetKeyUp("space"))
        {
            isJumping = false;
        }
        
        if(rb.velocity.y > 0)
        {
            GetComponent<Rigidbody>().AddForce(Physics.gravity * addedGravity, ForceMode.Acceleration);
        }
        

        

        if (Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))){
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }





    }

    private void FlipPlayer()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
        
    }
    //Exit Tunnel Spawn
    private void TunnelExit()
    {
  
            // Lerp between points
            transform.position = Vector3.Lerp(player.transform.position, moveTo.transform.position, Time.deltaTime * moveSpeed);

        

    }

    //Respawn at Tunnel
    private void OnTriggerEnter(Collider col)
    {
        switch (col.tag)
        {
            case "Death Zone1":

               
                gameManager.GetComponent<GameManager>().EndGame();
                

                break;


        }
    }

  

 
}
