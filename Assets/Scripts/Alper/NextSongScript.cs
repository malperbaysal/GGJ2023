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

    public void NextSong()
    {
        audioSource.clip =songs[i];
        audioSource.Play();
        i++;
    }
}
