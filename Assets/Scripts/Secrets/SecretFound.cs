using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SecretFound : MonoBehaviour
{
    [SerializeField] private string _text;
    [SerializeField] private TMP_Text _textMeshPro;
    [SerializeField] private GameObject _textMesh;
    [SerializeField] private Collider _collider;
    [SerializeField] private float _time = 2f;
    [SerializeField] private bool _activated = false;

    public void OutputText()
    {
        _textMeshPro.SetText(_text);
        _textMesh.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody && other.attachedRigidbody.GetComponent<PlayerMove>())
        {
            OutputText();
        }
    }

    public void Activated(bool activated)
    {
        _activated = activated;
        Debug.Log(_activated);
    }

    private void Update()
    {
        Debug.Log(_activated);
        if(_activated == true)
        {
            Debug.Log("startdisabled");
            StartDisable();
            //_activated = false;
        }
    }

    public void StartDisable()
    {
        StartCoroutine(Disappearance());
    }

    private IEnumerator Disappearance()
    {
                yield return new WaitForSeconds(_time);
                _textMesh.SetActive(false);
                Debug.Log("disabled");
    }
}

