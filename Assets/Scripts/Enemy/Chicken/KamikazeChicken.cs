using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KamikazeChicken : Chicken
{
    [SerializeField] private float _timeToExplode = 2f;
    [SerializeField] private float _distanceToActivateExplosion = 3.5f;
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private GameObject _explosionArea;
    [SerializeField] private Blink _blink;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        CheckDistance(_playerTransform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody && other.attachedRigidbody.GetComponent<Player>())
        {
            _blink.StartBlinking(3.1f);
        }
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = Rigidbody.mass * (toPlayer * Speed - Rigidbody.velocity) / TimeToReachSpeed;

        Rigidbody.AddForce(force);
    }

    private void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

            if (distance < _distanceToActivateExplosion)
            {
                StartExplosion();
            }
    }

    private void StartExplosion()
    {
        _timeToExplode -= Time.deltaTime;
        if(_timeToExplode <= 0f) 
        {
            Instantiate(_explosionEffect, transform.position, Quaternion.identity);
            Instantiate(_explosionArea, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
