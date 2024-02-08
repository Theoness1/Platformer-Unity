using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinSecret : MonoBehaviour
{
    [SerializeField] private GameObject _loot;
    private Vector3 _lootVector3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody && collision.rigidbody.GetComponent<Bullet>())
        {
            gameObject.transform.localScale -= Vector3.one;

            if (gameObject.transform.localScale == Vector3.zero)
            {
                _lootVector3 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1f, gameObject.transform.position.z);
                Instantiate(_loot, _lootVector3, Quaternion.identity);
                gameObject.SetActive(false);
            }
        }
    }
}
