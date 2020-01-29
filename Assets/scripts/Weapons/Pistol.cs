using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    public float damage;
    float IWeapon.damage { get => damage; set => damage = value; }
    public float bulletForce;
    float IWeapon.bulletForce { get => bulletForce; set => bulletForce = value; }
    public float RPM;
    float IWeapon.RPM { get => RPM; set => RPM = value; }


    public int nbBullet;
    int IWeapon.nbBullet { get => nbBullet; set => nbBullet = value; }

    public WeaponType weaponType = WeaponType.pistol;
    WeaponType IWeapon.weaponType { get => weaponType; set => weaponType = value; }


    // Start is called before the first frame update

    public void Setup(float rpm = 0.5f, float dmg = 1, int bullet = 1, float bulletSpeed = 20f)
    {
        RPM = rpm;
        damage = dmg;
        bulletForce = bulletSpeed;
        weaponType = WeaponType.pistol;
    }
    public void Shoot(GameObject bulletPrefab, Transform firePoint, Shooting shooter)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bul = bullet.GetComponent<Bullet>();
        if (bul != null)
        {
            bul.damage = damage * shooter.damage;
        }
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
