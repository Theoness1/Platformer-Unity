using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform _pointEnd;
    [SerializeField] private GameObject _player;
    [SerializeField] private AudioSource _teleportSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody && other.attachedRigidbody.GetComponent<PlayerMove>())
        {
            _teleportSound.Play();
            _player.transform.position = _pointEnd.transform.position;
            gameObject.SetActive(false);
        }
    }
}
