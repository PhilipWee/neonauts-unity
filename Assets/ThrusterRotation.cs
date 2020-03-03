using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterRotation : MonoBehaviour
{
    public float reaction_speed = 20f;
    public float thrust_magnitude = 10f;

    private HingeJoint2D pivot;
    private GameObject thruster_effector;
    private Vector3 thruster_effector_initial_pos;
    private Transform thruster_effector_transform;
    private PointEffector2D point_effector;
    // Start is called before the first frame update
    void Start()
    {
        pivot = GetComponent<HingeJoint2D>();

        thruster_effector_transform  = transform.Find("ThrustHolder");
        


        thruster_effector_initial_pos = thruster_effector_transform.localPosition;
        thruster_effector = thruster_effector_transform.gameObject;
        print(thruster_effector);
    }

    // Update is called once per frame
    void Update()
    {   
        //Code for rotating the thruster
        float horizontal_input = Input.GetAxis("Horizontal");
        float target_angle = Mathf.Lerp(20, -20, (horizontal_input+1)/2);
        float speed_required = target_angle - Mathf.Clamp(pivot.jointAngle,-20,20);
        JointMotor2D motor = pivot.motor;
        motor.motorSpeed = speed_required * reaction_speed;
        pivot.motor = motor;

        //Code for moving the thruster effector to always be at the initial pos
        thruster_effector.transform.localPosition = thruster_effector_initial_pos;

        //Code for making the amount the rocket moves based off the up button
        float vertical_input = Input.GetAxis("Vertical");
        point_effector = thruster_effector.GetComponent<PointEffector2D>();
        point_effector.forceMagnitude = Mathf.Clamp(vertical_input, 0, 1) * thrust_magnitude;
    }
}
