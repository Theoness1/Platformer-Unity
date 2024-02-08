using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceAndDisappearance : MonoBehaviour
{
    [SerializeField]
    private float _appearanceTime;
    [SerializeField]
    private float _disappearanceTime;
    private GameObject _player;
    [SerializeField] private Transform _transform;
    private bool _coroutineStart;
    private bool _coroutineEnd = true;


    void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody.GetComponent<Player>() && _coroutineStart != true)
            StartCoroutine(StartAppearance());
        Debug.Log(_coroutineStart);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<Player>() && _coroutineEnd == true)
            StartCoroutine(StartDisappearance());
        Debug.Log(_coroutineEnd);
    }

    private IEnumerator StartAppearance()
    {
        _transform.gameObject.SetActive(true);
        _coroutineStart = true;
        for(float t = 0; t < _appearanceTime; t += Time.deltaTime) 
        {
            _transform.localScale = Vector3.Lerp(_transform.localScale, new Vector3(0.7f, 0.7f, 0.7f), Time.deltaTime);
            if(_transform.localScale.x > 0.67f) {
                Debug.Log("A");
                _coroutineStart = false;
            }
            yield return null;
        }
    }

    private IEnumerator StartDisappearance()
    {
        _coroutineEnd = false;
        for (float t = 0; t < _disappearanceTime; t += Time.deltaTime)
        {
            _transform.localScale = Vector3.Lerp(_transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime);
            if (_transform.localScale.x < 0.25f)
            {
                Debug.Log("B");
                _coroutineEnd = true;
                _transform.gameObject.SetActive(false);
            }
            yield return null;
        }
    }
}
