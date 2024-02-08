using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShotGun : Gun
{
    [Header("ShotGun")]
    [SerializeField] private Transform[] _spawn;
    public int NumberOfBullets;
    public TMP_Text BulletsText;
    public PlayerArmory PlayerArmory;

    public override void CreateBullet()
    {
        if (NumberOfBullets != 0)
        {
            for (int i = 0; i < _spawn.Length; i++)
            {
                GameObject newBullet = Instantiate(BulletPrefab, _spawn[i].position, _spawn[i].rotation);
                newBullet.GetComponent<Rigidbody>().velocity = _spawn[i].forward * BulletSpeed;
            }
            ShotSound.Play();
            Flash.SetActive(true);
            Invoke("HideFlash", 0.1f);
            ShotEffect.Play();
            NumberOfBullets -= 1;
            UpdateText();
        }

        if (NumberOfBullets == 0) // мне кажется странно, что я здесь это сделал, костыльно.
        {
            PlayerArmory.DeactivateGun();
            Deactivate(); // деактивируем оружие, чтобы нельзя было его брать.
            PlayerArmory.TakeGunByIndex(0);
        }
    }

    public override void AddBullets(int numberOfBullets)
    {
        base.AddBullets(numberOfBullets);
        NumberOfBullets += numberOfBullets;
        UpdateText();
        PlayerArmory.TakeGunByIndex(2);
        PlayerArmory.ActivateGun(2); // активируем оружие, чтобы можно было его выбирать.
    }

    public override void Activate()
    {
        base.Activate();
        BulletsText.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        BulletsText.enabled = false;
    }

    private void UpdateText()
    {
        BulletsText.text = "Дробь: " + NumberOfBullets.ToString();
    }
}
