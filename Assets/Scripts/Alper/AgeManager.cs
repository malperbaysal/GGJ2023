using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Video;

public class AgeManager : MonoBehaviour
{
    [SerializeField]private VideoPlayer video;
    [SerializeField]private AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartMoving();
        }
    }

    void StartMoving()
    {
        transform.DOMoveX(-1000, 10).SetSpeedBased().SetEase(Ease.Linear);
        video.Play();
        music.Play();
    }
}
