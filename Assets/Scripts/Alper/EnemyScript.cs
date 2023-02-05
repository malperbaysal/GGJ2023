using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Vector3 firstPos;
    private Quaternion firstRotation;
    [SerializeField] private GameObject _origin;
    [SerializeField] private Rigidbody _activeRB;
    private bool _isDead;
    private BoxCollider _boxCollider;
    
    void Start()
    {
        firstPos = transform.GetChild(0).localPosition;
        firstRotation = transform.GetChild(0).localRotation;
        _boxCollider=transform.GetChild(0).GetComponent<BoxCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Die();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Revive();
        }
    }

    public void Die()
    {
        if(_isDead)
            return;
        _boxCollider.enabled = false;
        _activeRB.constraints = RigidbodyConstraints.None;
        _activeRB.isKinematic = false;
        _activeRB.AddForce(GetRandomForce(),ForceMode.Impulse);
        _activeRB.AddTorque(GetRandomForce(),ForceMode.Impulse);
        _isDead = true;
    }

    public void Revive()
    {
        if(!_isDead)
            return;
        _boxCollider.enabled = true;
        transform.GetChild(0).localPosition = firstPos;
        transform.GetChild(0).localRotation = firstRotation;
        _activeRB.constraints = RigidbodyConstraints.FreezeAll;
        _activeRB.isKinematic = true;
        _isDead = false;
    }

    Vector3 GetRandomForce()
    {
        Vector3 force;
        force = (Vector3.up * Random.Range(2.5f, 5f)) + (Vector3.right * Random.Range(5, 15f));
        force = force.normalized;
        force *= Random.Range(15, 25f);
        return force;
    }
}
