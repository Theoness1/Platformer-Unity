using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Rigidbody Rigidbody;

    private FixedJoint _fixedJoint;

    public Collider Collider;
    public Collider PlayerCollider;

    public RopeGun RopeGun;

    private void Start()
    {
        Physics.IgnoreCollision(Collider, PlayerCollider); // можно в старте получать коллайдеры наверн
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>(); // опасна€ дорожка. — проверкой норм
            if (collision.rigidbody)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }
            RopeGun.CreateSpring();
        }
    }

    public void DeleteFixedJoint()
    {
        if(_fixedJoint)
            Destroy(_fixedJoint);
    }
}
