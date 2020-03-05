using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterSide : MonoBehaviour
{
    //If clockwise is true, the thruster activates when turning clockwise, otehrwise it simply does not
    public bool clockwise = true;
    public float rotationForce = 5f;
    private ParticleSystem ps;
    private Rigidbody2D rb;
    public float StabaliserCutoff = 0.3f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
        //Rotate then fix the joint

    }

    // Update is called once per frame
    void Update()
    {   
        float horizontalInput = Input.GetAxis("Horizontal");

        if ((clockwise && horizontalInput>0) || (!clockwise && horizontalInput<0)) {
            // rb.AddRelativeForce(rotationForce * horizontalInput * Vector2.right);
            ActivatePS();
        } else if ((clockwise && rb.angularVelocity > StabaliserCutoff) || (!clockwise && rb.angularVelocity < -StabaliserCutoff)) {
            if (horizontalInput == 0){
                ActivatePS();
            }
        } else {
            DeactivatePS();
        }
        print(transform.rotation.eulerAngles);
        
    }

    void ActivatePS() {
        ps.Play();
    }

    void DeactivatePS() {
        ps.Stop();
    }

}
