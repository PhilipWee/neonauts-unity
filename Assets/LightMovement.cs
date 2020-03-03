using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
    public Vector3 startPos = new Vector3(0, 0, 0);

    public Vector3 endPos = new Vector3(0, 0, 0);

    public float travelTime = 10f;

    float startTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float fractionOfJourney = Mathf.Clamp((Time.time - startTime) / travelTime, 0f, 1f);

        transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);

    }
}
