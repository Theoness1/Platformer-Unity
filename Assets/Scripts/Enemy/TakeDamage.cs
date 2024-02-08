using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody && collision.rigidbody.GetComponent<Bullet>())
        {
            EnemyHealth.TakeDamage(1);
        }

        if (DieOnAnyCollision == true)
        {
            EnemyHealth.TakeDamage(100);
        }
    }
}
