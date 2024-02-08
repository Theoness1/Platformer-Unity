using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRocket : MonoBehaviour
{
    public GameObject EffectPrefab;
    [SerializeField] private GameObject _explosionArea;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _explosionArea.transform.position = collision.collider.ClosestPointOnBounds(transform.position);
        Instantiate(_explosionArea);
        Instantiate(EffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ракета взрывается при касании с колайдером противник (Сделано для триггер противников)
        if(other.gameObject.CompareTag("Enemy")) // Таг не у самого 1 по иерархии, а у Объекта с коллайдером.
        {
            _explosionArea.transform.position = other.transform.position;
            Instantiate(_explosionArea);
            Instantiate(EffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
