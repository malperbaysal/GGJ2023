using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YenidenPrefabimsi : MonoBehaviour
{
    public List<GameObject> squares;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate()
    {
        squares.Clear();
        foreach (var rigidbody in GetComponentsInChildren<Rigidbody>())
        {
            if(rigidbody.transform.parent.gameObject.activeSelf)
                squares.Add(rigidbody.transform.parent.gameObject);
        }
    }
}
