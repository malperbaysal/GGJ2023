using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private AgeManager _ageManager;
    public Animations animationsScript;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G) || Input.GetMouseButtonDown(0))
        {
            FirstAction();
        }

        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetMouseButtonDown(1))
        {
            SecondAction();
        }
    }

    void FirstAction()
    {
        //transform.DOLocalJump(new Vector3(transform.position.x,-3,transform.position.z), 2, 1, 0.40f);
        animationsScript.JumpAnim();
    }

    void SecondAction()
    {
        animationsScript.PunchAnim();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FlyingEnemies")||collision.gameObject.CompareTag("GroundEnemies"))
        {
            _ageManager.PlayerDied();
        }
        if (collision.gameObject.CompareTag("LevelEndingCube"))
        {
            print("UwU");
            _ageManager.NextAge(collision.transform);
        }
        /*
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.transform.parent.parent.name == "FlyingEnemies")
            {
                if (animationsScript.isAttackingUpPublic)
                {
                    collision.transform.parent.gameObject.GetComponent<EnemyScript>().Die();
                }
                else
                {
                    _ageManager.PlayerDied();
                }
            }

            if (collision.transform.parent.parent.name == "GroundEnemies")
            {
                if (animationsScript.isAttackingDownPublic)
                {
                    collision.transform.parent.gameObject.GetComponent<EnemyScript>().Die();
                }
                else
                {
                    _ageManager.PlayerDied();
                }
            }
        }
        */
        
    }
}