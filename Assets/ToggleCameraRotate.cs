using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCameraRotate : MonoBehaviour
{   
    public GameObject player;   

    public bool rotating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler (0.0f, 0.0f, player.transform.rotation.z * -1.0f);
    }

    private void LateUpdate() {
        //Maintain Child rotation without parent

    }
}
