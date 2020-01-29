using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    float RPM { get; set; }
    float damage { get; set; }
    float bulletForce { get; set; }
    int nbBullet { get; set; }
    WeaponType weaponType { get; set; }
    void Shoot(GameObject bulletPrefab, Transform firePoint, Shooting shooter);
    void Setup(float rpm, float dmg, int bullet, float bulletSpeed);
}
public enum WeaponType
{
    pistol,
    shotgun,
    burstM4,
    thompson
}