using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject weapon;
    public Transform firePoint;

    public int damage = 3;

    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public float RPM = 0.5f;
    private float nextTimeToFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        weapon.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + RPM;
            Shoot();
        }
    }

    private void Shoot()
    {
        weapon.GetComponent<IWeapon>().Shoot(bulletPrefab, firePoint, this);

    }
}
