using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DecoyJoke : MonoBehaviour
{
    [SerializeField] GameObject _gameObject;
    [SerializeField] GameObject _triggerGameObject;
    [SerializeField] AudioSource _audioSource;

    [SerializeField] UnityEvent _event;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody && other.attachedRigidbody.GetComponent<PlayerMove>())
        {
            Destroy(_gameObject);
            _event.Invoke();
            _audioSource.Play();
            Destroy(_triggerGameObject, 1);
        }
    }
}
