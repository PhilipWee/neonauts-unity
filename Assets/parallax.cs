using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{     
    Quaternion startRotation;
    private float length,height,maxDist;
    private Vector3 startpos;
    public GameObject cam;
    public GameObject player;
    public SpriteRenderer starsBackground;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {   
        startpos = cam.transform.position;
        length = starsBackground.bounds.size.x;
        height = starsBackground.bounds.size.y;
        maxDist = Mathf.Pow(length,2) + Mathf.Pow(height,2);
        startRotation = player.transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   

        //Parallax effect
        Vector3 dist = cam.transform.position * parallaxEffect;
        transform.position = startpos + dist;
        
        

        //Infinite effect
        Vector3 temp = (cam.transform.position * (1-parallaxEffect));
        // For y axis
        if (Mathf.Abs(temp.y - startpos.y) >= height){
            Vector3 displacement = new Vector3 (0,height,0);
            transform.position = transform.position + displacement;
            startpos = temp;
        }
        // For x axis
        if (Mathf.Abs(temp.x - startpos.x) >= length){
            Vector3 displacement = new Vector3 (length,0,0);
            transform.position = transform.position + displacement;
            startpos = temp;
        }


    }

    private void LateUpdate() {
        //Maintain Child rotation without parent
        transform.rotation = Quaternion.Euler (0.0f, 0.0f, player.transform.rotation.z * -1.0f);
    }
}
