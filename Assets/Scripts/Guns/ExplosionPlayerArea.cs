using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPlayerArea : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(3);
        }
    }
}
