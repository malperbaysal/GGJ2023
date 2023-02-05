using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Parallax parallax;

    private void Start()
    {
        parallax.MoveX();
    }
}
