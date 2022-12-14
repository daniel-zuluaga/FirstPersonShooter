using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ObjectPool bulletPool;
    public Transform muzzle;

    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    public float bulletSpeed;

    public float shootRate;
    private float lastShootTime;
    private bool isPlayer;

    public AudioClip shootSfx;
    private AudioSource audioSource;

    void Awake()
    {
        // are we attached to the player?
        if (GetComponent<PlayerController>())
            isPlayer = true;
        audioSource = GetComponent<AudioSource>();

    }

    // can we shoot a bullet?
    public bool CanShoot()
    {
        if (Time.time - lastShootTime >= shootRate)
        {
            if (curAmmo > 0 || infiniteAmmo == true)
                return true;
        }

        return false;
    }

    // called when we want to shoot a bullet
    public void Shoot()
    {
        lastShootTime = Time.time;
        curAmmo--;

        if (isPlayer)
            GameUI.instance.UpdateAmmoText(curAmmo, maxAmmo);

        audioSource.PlayOneShot(shootSfx);

        GameObject bullet = bulletPool.GetObject();

        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;

        // set the velocity
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }


}
