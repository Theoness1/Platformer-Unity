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
        // ������ ���������� ��� ������� � ���������� ��������� (������� ��� ������� �����������)
        if(other.gameObject.CompareTag("Enemy")) // ��� �� � ������ 1 �� ��������, � � ������� � �����������.
        {
            _explosionArea.transform.position = other.transform.position;
            Instantiate(_explosionArea);
            Instantiate(EffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
