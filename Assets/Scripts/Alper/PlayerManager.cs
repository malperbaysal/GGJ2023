using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)||Input.GetKeyDown(KeyCode.G))
        {
            FirstAction();
        }
        if (Input.GetKeyDown(KeyCode.J)||Input.GetKeyDown(KeyCode.K))
        {
            SecondAction();
        }
    }

    void FirstAction()
    {
        transform.DOLocalJump(new Vector3(transform.position.x,-3,transform.position.z), 2, 1, 0.5f);
    }
    void SecondAction()
    {
        
    }
}
