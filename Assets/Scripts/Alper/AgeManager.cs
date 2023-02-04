using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Video;

public class AgeManager : MonoBehaviour
{
    [SerializeField]private VideoPlayer video;
    [SerializeField]private AudioSource music;

    private Tween _tween;

    private Vector3 firstPoint;
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //_tween.PlayBackwards();
            _tween=transform.DOMoveX(firstPoint.x, 100).SetSpeedBased().SetEase(Ease.Linear).OnComplete(StartMoving);
        }
    }

    void StartMoving()
    {
        firstPoint = transform.position;
        _tween=transform.DOMoveX(-1000, 10).SetSpeedBased().SetEase(Ease.Linear);
        video.Play();
        music.Play();
    }
}
