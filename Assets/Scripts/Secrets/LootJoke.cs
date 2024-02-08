using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootJoke : MonoBehaviour
{
    [SerializeField] BatchPrefabCreator _creator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerHealth player))
        {
            _creator.Create();
        }
    }
}
