using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{

    void Shoot(GameObject bulletPrefab, Transform firePoint, Shooting shooter);
    void Setup(float rpm, int dmg, int bullet, float bulletSpeed);
}
public enum WeaponType
{
    pistol,
    shotgun,
    burstM4
}