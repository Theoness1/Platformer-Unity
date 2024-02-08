using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDeactivate : MonoBehaviour
{
    [SerializeField] GameObject _hook;
    [SerializeField] RopeGun _spring;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody.TryGetComponent(out Hook hook))
        {
            _hook.SetActive(false);
            _spring.DestroySpring();
        }
    }
}
