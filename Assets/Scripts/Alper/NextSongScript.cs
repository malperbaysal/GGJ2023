using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSongScript : MonoBehaviour
{
    public List<AudioClip> songs;
    public AudioSource audioSource;
    private int i;

    private void Start()
    {
        i++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            audioSource.pitch = Time.timeScale = 5;
        if (Input.GetKeyUp(KeyCode.P))
            audioSource.pitch = Time.timeScale = 1;
    }

    public void NextSong()
    {
        audioSource.clip =songs[i];
        audioSource.Play();
        i++;
    }
}
