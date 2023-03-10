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
    
    
    [SerializeField] private GameObject currentAge;
    public NextSongScript NextSongScript;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartMoving",0.1f);
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

        _tween = transform.DOMoveX(-100000, 10).SetSpeedBased().SetEase(Ease.Linear);
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
        yield return new WaitForSeconds(1.03f);
        music.Play();
    }

    public void NextAge(Transform cubeTransform)
    {
        firstPoint = new Vector3(cubeTransform.position.x,firstPoint.y,firstPoint.z);
        ChangeCharacter();
        ParalaxPlacesSet();
        NextSongScript.NextSong();
    }

    void ChangeCharacter()
    {
        var  playerManager =FindObjectOfType<PlayerManager>();
        //var playerObj = playerManager.gameObject;
        for (int i = 0; i < playerManager.transform.childCount; i++)
        {
            if (playerManager.transform.GetChild(i).gameObject.activeSelf)
            {
                playerManager.transform.GetChild(i).gameObject.SetActive(false);
                playerManager.transform.GetChild(i+1).gameObject.SetActive(true);
                playerManager.animationsScript = playerManager.transform.GetChild(i + 1).GetComponent<Animations>();
                break;
            }
        }
    }
    public void PlayerDied()
    {
        var EnemeyReviver = GetComponentsInChildren<EnemyScript>();
        foreach (var enemies in EnemeyReviver)
        {
            enemies.Revive();
        }
        music.Stop();
        _tween.Kill();
        _groundTween.Kill();
        _tween = transform.DOMoveX(firstPoint.x - 1, 0.5f) /*.SetSpeedBased()*/.SetEase(Ease.Linear)
            .OnComplete((() => StartCoroutine(DelayBeforeRestart())));
        _groundTween = _ground.transform.DOMoveX(firstPoint.x - 1, 0.5f) /*.SetSpeedBased()*/.SetEase(Ease.Linear);
        for (int i = 0; i < _paralax.Count; i++)
        {
            Parallax Parallax = _backGround.GetComponent<Parallax>();
            
            _paralax[i].transform.DOMove(_paralaxPlaces[i], 0.5f) /*.SetSpeedBased()*/.SetEase(Ease.Linear);
            
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