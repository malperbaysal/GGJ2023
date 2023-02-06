using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YenidenPrefabimsi : MonoBehaviour
{
    public List<GameObject> squares;
    public List<GameObject> news;

    public enum Level {first, second, third, forth};

    public Level level;
    public GameObject fi, se, th, fo;
    public bool once;
    private void OnValidate()
    {
        if(once)
            return;
        once=true;
        squares.Clear();
        foreach (var rigidbody in GetComponentsInChildren<Rigidbody>())
        {
            if(rigidbody.transform.parent.gameObject.activeSelf)
                squares.Add(rigidbody.transform.parent.gameObject);
        }

        
        PlaceEnemies();
    }

    void PlaceEnemies()
    {
        GameObject toInstantia=fi;
        

        foreach (var VARIABLE in squares)
        {
            var fgjnb= Instantiate(fi, VARIABLE.transform.position, fi.transform.rotation);
            fgjnb.transform.parent = VARIABLE.transform.GetChild(0);
            fgjnb.transform.parent.localScale = Vector3.one;
            fgjnb.name = "sikik";
            VARIABLE.GetComponentInParent<MeshRenderer>().enabled = false;
            news.Add(fgjnb);
        }
    }
}
