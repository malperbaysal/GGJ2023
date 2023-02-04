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
        parallax1.DOMoveX(-1000, 1).SetSpeedBased().SetEase(Ease.Linear);
        parallax2.DOMoveX(-1000, 5).SetSpeedBased().SetEase(Ease.Linear);
        parallax3.DOMoveX(-1000, 6).SetSpeedBased().SetEase(Ease.Linear);
        parallax4.DOMoveX(-1000, 8).SetSpeedBased().SetEase(Ease.Linear);
    }
}
