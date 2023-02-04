using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject _origin;
    [SerializeField] private GameObject _active;
    [SerializeField] private Rigidbody _activeRB;
    [SerializeField] private Rigidbody _originRB;
    private bool _isDead;
    void Start()
    {
        
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
        _activeRB.constraints = RigidbodyConstraints.None;
        _activeRB.isKinematic = false;
        _activeRB.AddForce(GetRandomForce(),ForceMode.Impulse);
        _activeRB.AddTorque(GetRandomForce(),ForceMode.Impulse);
        Destroy(_active,2f);
        _isDead = true;
    }

    public void Revive()
    {
        if(!_isDead)
            return;
        var newActive = Instantiate(_origin, _origin.transform.position, _origin.transform.rotation,
            _origin.transform.parent);
        _active = newActive;
        _activeRB = _active.GetComponent<Rigidbody>();
        _active.SetActive(true);
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
