using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Automat : Gun
{
    [Header("Automat")]
    public int NumberOfBullets;
    public TMP_Text BulletsText;
    public PlayerArmory PlayerArmory;

    public override void CreateBullet()
    {
        if (NumberOfBullets != 0)
        {
            base.CreateBullet();
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
        PlayerArmory.TakeGunByIndex(1);
        PlayerArmory.ActivateGun(1); // активируем оружие, чтобы можно было его выбирать.
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
        BulletsText.text = "Пули: " + NumberOfBullets.ToString();
    }

}
