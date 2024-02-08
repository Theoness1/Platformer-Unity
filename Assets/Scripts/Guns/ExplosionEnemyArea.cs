using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemyArea : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(1);
        }
    }
}
