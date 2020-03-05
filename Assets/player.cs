using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float rotationTorque = 200f;
    public float correctingSpeed = 20;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() {
        //Perform a rotation of the rocket on the spot
        float HorizontalInput = Input.GetAxis("Horizontal");
        rb.AddTorque(-HorizontalInput * rotationTorque);

        //Restabalise the rotation depending on how you are rotating
        // print(rb.angularVelocity);
        if (HorizontalInput == 0) {
            
            float ForceApplied = Mathf.Clamp(rb.angularVelocity*correctingSpeed,-rotationTorque,rotationTorque);
            // print(ForceApplied);
            rb.AddTorque(-ForceApplied);
        }
    }

}
