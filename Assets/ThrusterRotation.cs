using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterRotation : MonoBehaviour
{
    public float reaction_speed = 20f;
    public float thrust_magnitude = 10f;

    private HingeJoint2D pivot;
    private GameObject FlameStream;
    private Rigidbody2D thruster_rb;
    // Start is called before the first frame update
    void Start()
    {
        pivot = GetComponent<HingeJoint2D>();
        thruster_rb = GetComponent<Rigidbody2D>();
        FlameStream = transform.Find("FlameStream").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        //Code for rotating the thruster
        float horizontal_input = Input.GetAxis("Horizontal");
        float target_angle = Mathf.Lerp(20, -20, (horizontal_input+1)/2);
        float speed_required = target_angle - Mathf.Clamp(pivot.jointAngle,-20,20);
        JointMotor2D motor = pivot.motor;
        motor.motorSpeed = speed_required * reaction_speed;
        pivot.motor = motor;

        //Code for making the amount the rocket moves based off the up button
        //Note that we have switched to using the up of the transform cos point effectors didnt work
        float vertical_input = Input.GetAxis("Vertical");
        thruster_rb.AddRelativeForce(Mathf.Clamp(vertical_input, 0, 1) * thrust_magnitude * Vector2.up);

        //Show the flames if there is vertical input
        if (vertical_input > 0) {
            FlameStream.SetActive(true);
        } else {
            FlameStream.SetActive(false);
        }
        
    }
}
