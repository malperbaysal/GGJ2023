using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerTest : MonoBehaviour
{
    public AudioSource source;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            source.pitch = Time.timeScale = 0.5f;
        }
        else
        {
            source.pitch = Time.timeScale = 1;
        }
    }
    
}
