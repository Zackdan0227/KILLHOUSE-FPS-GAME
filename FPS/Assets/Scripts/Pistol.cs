using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    // Start is called before the first frame update

    public float fireRate = 5;
    public AudioConfigScriptableObject AudioConfig;

    public AudioSource ShootingAudioSource;
    private float nextFireTime = 0f;
    public void Start()
    {
        //    GameManager.instance.playerStats.ammo = 0;

        ShootingAudioSource = GetComponent<AudioSource>();
    }
    public override void Fire()
    {
        if (Time.time >= nextFireTime && GameManager.instance.playerStats.ammo > 0)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<UnityEngine.Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;// Fire the pistol
            AudioConfig.PlayShootingCLip(ShootingAudioSource, GameManager.instance.playerStats.ammo == 1);
            nextFireTime = Time.time + 1f / fireRate;
            GameManager.instance.playerStats.ammo--;
        }
        else if (GameManager.instance.playerStats.ammo == 0)
        {
            AudioConfig.PlayOutOfAmmoClip(ShootingAudioSource);
        }

        // Code to fire the weapon goes here

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (GameManager.instance.playerStats.ammo != 5)
            {
                StartReloading();
                GameManager.instance.playerStats.ammo = 5;
            }
        }
    }
    public void StartReloading()
    {
        AudioConfig.PlayReloadClip(ShootingAudioSource);
    }
}