using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerArmory : MonoBehaviour
{
    public Gun[] Guns;
    public int CurrentGunIndex;
    [SerializeField] AudioSource PickUpSound;
    private int _gunIndexActivate;

    private void Start()
    {
        TakeGunByIndex(CurrentGunIndex);
    }

    private void Update()
    {
        ChangeGunByKey();
        Debug.Log(_gunIndexActivate);
    }

    public void TakeGunByIndex(int gunIndex)
    {
        CurrentGunIndex = gunIndex;
        for (int i = 0; i < Guns.Length; i++)
        {
            if (i == gunIndex)
            {
                Guns[i].Activate();
            }
            else
            {
                Guns[i].Deactivate();
            }
        }
    }

    public void AddBullets(int gunIndex, int numberOfBullets)
    {
        Guns[gunIndex].AddBullets(numberOfBullets);
        PickUpSound.Play();
    }

    private void ChangeGunByKey()
    {
        if(Input.GetKey(KeyCode.F)) 
        {
            TakeGunByIndex(CurrentGunIndex = 0);
        }

        if(Input.GetKey(KeyCode.G)) //пофиксить, дроб 2, базука 3. && ActivateGun(_gunIndexActivate) == 1
        {
            TakeGunByIndex(CurrentGunIndex = 1);
        }

        if(Input.GetKey(KeyCode.H))
        {
            TakeGunByIndex(CurrentGunIndex = 2);
        }

        if (Input.GetKey(KeyCode.J))
        {
            TakeGunByIndex(CurrentGunIndex = 3);
        }
    }

    public int ActivateGun(int gunIndex) // оружие надо переключать, но индекс постоянный ставиться, надо может массив проверять или чо
    {
        _gunIndexActivate = gunIndex;
        return _gunIndexActivate;
    }

    public void DeactivateGun()
    {
        _gunIndexActivate = 0;
    }
}
