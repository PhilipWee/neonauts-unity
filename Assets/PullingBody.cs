using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingBody : MonoBehaviour
{
    const float G = 6.674f;

    public static List<AttractedBody> attracteds;

    public Rigidbody2D rb;

    public float pullingBodyMass = 1;

    void Start()
    {
        rb.mass = pullingBodyMass;
    }

    void FixedUpdate()
    {
        foreach (AttractedBody attracted in attracteds)
        {
            Attract(attracted);
        }

    }

    void OnEnable ()
    {
        if (attracteds == null)
        {
            attracteds = new List<AttractedBody>();
        }
    }
    
    void Attract (AttractedBody objToAttract)
    {
        Rigidbody2D rbToAttract = objToAttract.rb;
        Vector2 direction = rb.position - rbToAttract.position;
        float r = direction.magnitude;

        if (r == 0f)
        {
            return;
        }

        float forceMagnitude = G * rb.mass * rbToAttract.mass / Mathf.Pow(r, 2);
        Vector2 force = forceMagnitude * direction.normalized;

        rbToAttract.AddForce(force);

    }

}
