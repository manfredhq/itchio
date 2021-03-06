﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour , IWeapon
{
    public string weaponName;
    string IWeapon.weaponName { get => weaponName; set => weaponName = value; }
    public float damage;
    float IWeapon.damage { get => damage; set => damage = value; }
    public float bulletForce;
    float IWeapon.bulletForce { get => bulletForce; set => bulletForce = value; }
    public float RPM;
    float IWeapon.RPM { get => RPM; set => RPM = value; }


    public int nbBullet;
    int IWeapon.nbBullet { get => nbBullet; set => nbBullet = value; }

    public WeaponType weaponType = WeaponType.shotgun;
    WeaponType IWeapon.weaponType { get => weaponType; set => weaponType = value; }


    // Start is called before the first frame update
    public void Setup(float rpm = 0.5f, float dmg = 1, int bullet = 1, float bulletSpeed = 20f)
    {
        nbBullet = bullet;
        RPM = rpm;
        damage = dmg;
        bulletForce = bulletSpeed;
        weaponType = WeaponType.shotgun;
        weaponName = "Shotgun";
    }

    public void Shoot(GameObject bulletPrefab, Transform firePoint, Shooting shooter)
    {

        GameObject bullet1 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bul1 = bullet1.GetComponent<Bullet>();
        if (bul1 != null)
        {
            bul1.damage = damage * shooter.damage;
        }
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        rb1.AddForce((firePoint.right) * bulletForce, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bul2 = bullet2.GetComponent<Bullet>();
        if (bul2 != null)
        {
            bul2.damage = damage * shooter.damage;
        }
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce((firePoint.right) * bulletForce, ForceMode2D.Impulse);

        GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bul3 = bullet3.GetComponent<Bullet>();
        if (bul3 != null)
        {
            bul3.damage = damage * shooter.damage;
        }
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.AddForce((firePoint.right) * bulletForce, ForceMode2D.Impulse);
        
        
        if (nbBullet % 2 == 0)
        {
            for (int i = 0; i < nbBullet; i++)
            {
                if (i % 2 == 0)
                {

                }
                else
                {
                    for (int i2 = 0; i2 < nbBullet; i2++)
                    {
                        if (i2 % 2 == 0)
                        {
                            
                        }
                        else
                        {

                        }
                        
                    }
                    
                }
                
            }

        }
        
        
    }
}
