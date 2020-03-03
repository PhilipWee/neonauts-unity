using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRise : MonoBehaviour
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
        float fractionOfJourney = Mathf.Clamp((Time.time - startTime)/travelTime, 0f, 1f);

        transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);

    }
}

//void Start()
//{
//    // Keep a note of the time the movement started.
//    startTime = Time.time;

//    // Calculate the journey length.
//    journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
//}

//// Move to the target end position.
//void Update()
//{
//    // Distance moved equals elapsed time times speed..
//    float distCovered = (Time.time - startTime) * speed;

//    // Fraction of journey completed equals current distance divided by total distance.
//    float fractionOfJourney = distCovered / journeyLength;

//    // Set our position as a fraction of the distance between the markers.
//    transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
//}
//}