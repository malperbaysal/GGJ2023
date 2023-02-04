using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length,startPos;
    public GameObject cam;
    public float parallaxEffect;
    public static Parallax instance;
    private Tween tween;
    public Transform parallax1;
    public Transform parallax2;
    public Transform parallax3;
    public Transform parallax4;
    public Tween parallaxTween1;
    public Tween parallaxTween2;
    public Tween parallaxTween3;
    public Tween parallaxTween4;
    private void Awake()
    {
        if (instance != null) {
            Destroy(this);
            return;
        }

        instance = this;
    }
    

    private void Start()
    {
        // startPos = transform.position.x;
        // length = GetComponent<SpriteRenderer>().bounds.size.x;
        //MoveX();
    }

    private void FixedUpdate()
    {
        // float temp = cam.transform.position.x * (1 - parallaxEffect);
        // float dist = (cam.transform.position.x * parallaxEffect);
        // transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        //
        // if (temp > startPos + length) startPos += length;
        // else if (temp < startPos - length) startPos -= length;

    }

    public void MoveX()
    {
        if (tween.IsActive())
            return;
        
        //tween=transform.DOMoveX(-1000, 10).SetSpeedBased().SetEase(Ease.Linear);
        parallaxTween1=parallax1.DOMoveX(-1000, 1).SetSpeedBased().SetEase(Ease.Linear);
        parallaxTween2=parallax2.DOMoveX(-1000, 2).SetSpeedBased().SetEase(Ease.Linear);
        parallaxTween3=parallax3.DOMoveX(-1000, 4).SetSpeedBased().SetEase(Ease.Linear);
        parallaxTween4=parallax4.DOMoveX(-1000, 8).SetSpeedBased().SetEase(Ease.Linear);
    }
}
