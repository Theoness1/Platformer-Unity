using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;
    //[SerializeField] private GameObject _secretItem;
    //[SerializeField] private Vector3 _vectorY;

    private void OnCollisionEnter(Collision collision)
    {
        /*if(_secretItem != null)
        {
            Instantiate(_secretItem, new Vector3(transform.position.x, _vectorY.y), Quaternion.identity);
        }*/
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
