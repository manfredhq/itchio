using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstM4 : MonoBehaviour, IWeapon
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
    
    public WeaponType weaponType = WeaponType.burstM4;
    WeaponType IWeapon.weaponType { get => weaponType; set => weaponType = value; }



    // Start is called before the first frame update

    public void Setup(float rpm = 0.5f, float dmg = 1, int bullet = 1, float bulletSpeed = 20f)
    {
        RPM = rpm;
        damage = dmg;
        bulletForce = bulletSpeed;
        weaponType = WeaponType.burstM4;
        weaponName = "M4";

    }
    public void Shoot(GameObject bulletPrefab, Transform firePoint, Shooting shooter)
    {
        
        StartCoroutine(Temporise( bulletPrefab, firePoint, shooter));
        
    }

    IEnumerator Temporise( GameObject bulletPrefab, Transform firePoint, Shooting shooter)
    {
        for (int i = 0; i < nbBullet; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bul = bullet.GetComponent<Bullet>();
            if (bul != null)
            {
                bul.damage = damage * shooter.damage;
            }
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
            yield return new WaitForSecondsRealtime(0.075f);
        }
        
    }
}
