using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private AgeManager _ageManager;
    public Animations animationsScript;

    void Start()
    {
      
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)||Input.GetKeyDown(KeyCode.G))
        {
            FirstAction();
            animationsScript.JumpAnim();
        }
        if (Input.GetKeyDown(KeyCode.J)||Input.GetKeyDown(KeyCode.K))
        {
            SecondAction();
            animationsScript.PunchAnim();
        }
    }

    void FirstAction()
    {
        //transform.DOLocalJump(new Vector3(transform.position.x,-3,transform.position.z), 2, 1, 0.40f);
    }
    void SecondAction()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            print("Obstacle");
        }
        if (collision.gameObject.CompareTag("LevelEndingCube"))
        {
            _ageManager.NextAge();
            print("UwU");
        }
    }
}
