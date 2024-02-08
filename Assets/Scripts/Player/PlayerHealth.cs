using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 5;

    private bool _invulnerable = false;

    //public AudioSource TakeDamageSound;
    public AudioSource HealSound;

    public HealthUI HealthUI;

    //public DamageScreen DamageScreen;
    //public Blink Blink;

    public UnityEvent EventOnTakeDamage;

    private void Start()
    {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }

    public void TakeDamage(int damage)
    {
        if(_invulnerable == false)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            _invulnerable = true;
            Invoke("StopInvulnerable", 1f);
            HealthUI.DisplayHealth(Health);

            EventOnTakeDamage.Invoke();
        }
    }

    private void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int health)
    {
        Health += health;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        HealSound.Play();
        HealthUI.DisplayHealth(Health);
    }

    public void Die()
    {

    }
}
