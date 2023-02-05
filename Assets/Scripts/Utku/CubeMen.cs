using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeMen : MonoBehaviour
{
    Tween upTween;
    Tween downTween;

    public float duration;
    public float upDistance;
    public float downDistance;

    void Start()
    {
        GoUp();
    }


    private void GoUp()
    {
        downTween.Kill();
        upTween = transform.DOMoveY(upDistance, duration).SetEase(Ease.InBounce).OnComplete(() => GoDown());
    }


    private void GoDown()
    {
        downTween.Kill();
        upTween = transform.DOMoveY(downDistance, duration).SetEase(Ease.InBounce).OnComplete(() => GoUp());
    }
}
