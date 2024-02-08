using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCloud : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private bool _launch = false;

    public IEnumerator StartMoving()
    {
        for (float t = 46; t > 0; t -= Time.deltaTime)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _target.position, 3f * Time.deltaTime);
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody && collision.rigidbody.GetComponent<PlayerHealth>() && _launch == false)
        {
            _launch = true;
            StartCoroutine(StartMoving());
        }
    }
}
