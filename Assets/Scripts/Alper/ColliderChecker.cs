using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColliderChecker : MonoBehaviour
{
    public List<Transform> listOfCloseNotesDown;
    public List<Transform> listOfCloseNotesUp;
    public ParticleSystem particle;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G) || Input.GetMouseButtonDown(0))
        {
            UpHitDecider();
        }

        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetMouseButtonDown(1))
        {
            DownHitDecider();
        }
    }

    void UpHitDecider()
    {
        if (listOfCloseNotesUp.Count==0)
        {
            return;
        }
        if ((ClosestOneUp().position.x-transform.parent.position.x)<3f)
        {
            ClosestOneUp().GetComponentInParent<EnemyScript>().Die();
            ParticleSystem particleSystem= Instantiate(particle, particle.transform.position, particle.transform.rotation);
            particleSystem.Play();
        }
    }void DownHitDecider()
    {
        if (listOfCloseNotesDown.Count==0)
        {
            return;
        }
        if ((ClosestOneDown().position.x-transform.parent.position.x)<3f)
        {
            ClosestOneDown().GetComponentInParent<EnemyScript>().Die();
            ParticleSystem particleSystem= Instantiate(particle, particle.transform.position, particle.transform.rotation);
            particleSystem.Play();
        }
    }
    
    Transform ClosestOneUp()
    {
        return listOfCloseNotesUp.OrderBy(t => t.position.x).First();
    }
    Transform ClosestOneDown()
    {
        return listOfCloseNotesDown.OrderBy(t => t.position.x).First();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GroundEnemies"))
        {
            listOfCloseNotesDown.Add(other.transform);
        }

        if (other.CompareTag("FlyingEnemies"))
        {
            listOfCloseNotesUp.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.parent.name == "GroundEnemies")
        {
            listOfCloseNotesDown.Remove(other.transform);
        }

        if (other.transform.parent.parent.name == "FlyingEnemies")
        {
            listOfCloseNotesUp.Remove(other.transform);
        }
    }
}