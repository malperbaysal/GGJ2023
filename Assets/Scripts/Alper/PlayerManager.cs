using System.Collections;
using System.Collections.Generic;
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
        
    }
    void SecondAction()
    {
        
    }
}
