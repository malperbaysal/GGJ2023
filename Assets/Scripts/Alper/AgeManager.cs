using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Video;

public class AgeManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] private AudioSource music;

    private Tween _tween;
    private Tween _groundTween;

    private Vector3 firstPoint;

    public bool testing;

    public float delay;

    [SerializeField] private GameObject _ground;
    [SerializeField] private GameObject _backGround;
    [SerializeField] private List<GameObject> _paralax;

    [SerializeField] private List<Vector3> _paralaxPlaces;

    // Start is called before the first frame update
    void Start()
    {
        firstPoint = transform.position;
        ParalaxPlacesSet();
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

        _tween = transform.DOMoveX(-1000, 10).SetSpeedBased().SetEase(Ease.Linear);
        _groundTween = _ground.transform.DOMoveX(-1000, 6.5f).SetSpeedBased().SetEase(Ease.Linear);
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

    private void OnValidate()
    {
        /*
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
            */
        _paralax.Clear();
        foreach (Transform child in _backGround.transform)
        {
            if (child.transform.childCount > 0)
            {
                _paralax.Add(child.gameObject);
                foreach (Transform grandChild in child.transform)
                {
                    _paralax.Add(grandChild.gameObject);
                }
            }
            else
            {
                _paralax.Add(child.gameObject);
            }
        }
    }

    IEnumerator DelayBeforeMusic()
    {
        yield return new WaitForSeconds(0.9f);
        music.Play();
    }

    public void NextAge()
    {
        firstPoint = transform.position;
        ParalaxPlacesSet();
    }

    public void PlayerDied()
    {
        _tween.Kill();
        _groundTween.Kill();
        _tween = transform.DOMoveX(firstPoint.x - 1, 0.5f) /*.SetSpeedBased()*/.SetEase(Ease.Linear)
            .OnComplete((() => StartCoroutine(DelayBeforeRestart())));
        _groundTween = _ground.transform.DOMoveX(firstPoint.x - 1, 0.5f) /*.SetSpeedBased()*/.SetEase(Ease.Linear);
        for (int i = 0; i < _paralax.Count; i++)
        {
            Parallax Parallax = _backGround.GetComponent<Parallax>();
            
            _paralax[i].transform.DOMove(_paralaxPlaces[i], 0.5f) /*.SetSpeedBased()*/.SetEase(Ease.Linear).OnComplete(Parallax.MoveX);
            
            Parallax.parallaxTween1.Kill();
            Parallax.parallaxTween2.Kill();
            Parallax.parallaxTween3.Kill();
            Parallax.parallaxTween4.Kill();
        }
    }

    void ParalaxPlacesSet()
    {
        foreach (var pos in _paralax)
        {
            _paralaxPlaces.Add(pos.transform.position);
        }
    }
}