using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ObsticlePlacer : MonoBehaviour
{
    [SerializeField] List<GameObject> _spikes;
    [SerializeField] bool _place;
    [SerializeField] float _distanceBetween;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnValidate()
    {
        if (_place)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).localPosition = new Vector3(i * _distanceBetween, 0, 0);
            }
        }
    }
}
