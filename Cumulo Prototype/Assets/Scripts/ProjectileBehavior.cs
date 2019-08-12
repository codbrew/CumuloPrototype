using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float moveSpeed = 750f;
    
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.right * moveSpeed *Time.deltaTime);
     
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
