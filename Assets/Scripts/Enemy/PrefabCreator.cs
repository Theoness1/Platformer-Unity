using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private Transform Spawn;

    public void Create() // вообще переделать все создания и уничтожения и добавить ObjectPool
    {
        Instantiate(Prefab, Spawn.position, Spawn.rotation);
    }
}
