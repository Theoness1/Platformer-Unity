using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Booba : MonoBehaviour
{
    [SerializeField] private string _text;
    [SerializeField] private TMP_Text _textMeshPro;
    [SerializeField] private GameObject _textMesh;
    [SerializeField] private float _time = 2f;
    [SerializeField] private bool activated = false;
    [SerializeField] private SecretFound SecretFound;

    public void OutputText()
    {
        _textMeshPro.SetText(_text);
        _textMesh.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody && other.attachedRigidbody.GetComponent<PlayerMove>())
        {
            SecretFound.Activated(true);
        }
    }
}
