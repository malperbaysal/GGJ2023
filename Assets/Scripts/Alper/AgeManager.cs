using System;
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
    private Tween _groundTween;

    private Vector3 firstPoint;

    public bool testing;

    public float delay;

    [SerializeField] private GameObject _ground;
    // Start is called before the first frame update
    void Start()
    {
        firstPoint = transform.position;
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
            PlayerDied();
        }
    }

    IEnumerator DelayBeforeRestart()
    {
        yield return new WaitForSeconds(0.75f);
        StartMoving();
    }

    void StartMoving()
    {
        if (_tween.IsActive())
            return;
        
        _tween=transform.DOMoveX(-1000, 10).SetSpeedBased().SetEase(Ease.Linear);
        _groundTween=_ground.transform.DOMoveX(-1000, 6.5f).SetSpeedBased().SetEase(Ease.Linear);
        Parallax.instance.MoveX();
        MusicPlay();
        /*
        video.Play();
        music.Play();
        */
    }

    void MusicPlay()
    {
        //video.Play();
        StartCoroutine(DelayBeforeMusic());
    }
    /*
    private void OnValidate()
    {
        if (testing)
        {
            //video.Play(); - 0.9
            music.Play();
            StartCoroutine(DelayBeforeMusic());
        }
        else
        {
            video.Stop();
            music.Stop();
        }
        
    }
    */
    IEnumerator DelayBeforeMusic()
    {
        yield return new WaitForSeconds(0.9f);
        music.Play();
    }

    public void NextAge()
    {
        firstPoint = transform.position;
    }

    public void PlayerDied()
    {
        _tween.Kill();
        _groundTween.Kill();
        _tween=transform.DOMoveX(firstPoint.x-1, 0.5f)/*.SetSpeedBased()*/.SetEase(Ease.Linear).OnComplete((() => StartCoroutine(DelayBeforeRestart())));
        _groundTween=_ground.transform.DOMoveX(firstPoint.x-1, 0.5f)/*.SetSpeedBased()*/.SetEase(Ease.Linear).OnComplete((() => StartCoroutine(DelayBeforeRestart())));
    }
}
