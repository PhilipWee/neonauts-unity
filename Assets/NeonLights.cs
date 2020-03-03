using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class NeonLights : MonoBehaviour
{
    private TextMeshPro neonText;
    private float startTime;
    private bool isCoroutineExecuting = false;
    // Start is called before the first frame update
    void Start()
    {
        neonText = GetComponent<TextMeshPro>();
        neonText.fontSharedMaterial.SetFloat("_GlowPower", 0f);
        StartCoroutine(ExecuteAfterTime(3f, () => {
            StartCoroutine(Flashing());
        }));
    }
    
    IEnumerator Flashing()
    {   
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (neonText.fontSharedMaterial.GetFloat("_GlowPower") == 1f) 
            {
                neonText.fontSharedMaterial.SetFloat("_GlowPower", 0.1f);
            } else
            {
                neonText.fontSharedMaterial.SetFloat("_GlowPower", 1f);
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
