using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    public int Damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody && collision.rigidbody.GetComponent<PlayerHealth>())
        {
            collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }
    }
}
