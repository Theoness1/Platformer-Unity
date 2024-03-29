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

        if (NumberOfBullets == 0) // ��� ������� �������, ��� � ����� ��� ������, ���������.
        {
            PlayerArmory.DeactivateGun();
            Deactivate(); // ������������ ������, ����� ������ ���� ��� �����.
            PlayerArmory.TakeGunByIndex(0);
        }
    }

    public override void AddBullets(int numberOfBullets)
    {
        base.AddBullets(numberOfBullets);
        NumberOfBullets += numberOfBullets;
        UpdateText();
        PlayerArmory.TakeGunByIndex(1);
        PlayerArmory.ActivateGun(1); // ���������� ������, ����� ����� ���� ��� ��������.
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
        BulletsText.text = "����: " + NumberOfBullets.ToString();
    }

}
