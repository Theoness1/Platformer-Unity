using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Spawn;
    public float BulletSpeed;
    public float ShotPeriod;

    public AudioSource ShotSound;
    public GameObject Flash;

    private float _timer;

    public ParticleSystem ShotEffect;

    private void Update()
    {
        _timer += Time.unscaledDeltaTime;
        if (_timer > ShotPeriod && Input.GetMouseButton(0))
        {
            _timer = 0f;
            CreateBullet();
        }
    }

    public virtual void CreateBullet()
    {
        GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;
        ShotSound.Play();
        Flash.SetActive(true);
        Invoke("HideFlash", 0.1f);
        ShotEffect.Play();
    }

    public virtual void AddBullets(int numberOfBullets)
    {

    }

    private void HideFlash()
    {
        Flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
