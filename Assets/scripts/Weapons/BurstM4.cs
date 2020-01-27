using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstM4 : MonoBehaviour, IWeapon
{
    public float damage;
    public float bulletForce;
    public float RPM;
    public int nbBullet;
    public WeaponType weaponType = WeaponType.pistol;


    // Start is called before the first frame update

    public void Setup(float rpm = 0.5f, int dmg = 1, int bullet = 1, float bulletSpeed = 20f)
    {
        RPM = rpm;
        damage = dmg;
        bulletForce = bulletSpeed;
        weaponType = WeaponType.pistol;
    }
    public void Shoot(GameObject bulletPrefab, Transform firePoint, Shooting shooter)
    {
        
        StartCoroutine(Temporise(RPM, bulletPrefab, firePoint, shooter));
        
    }

    IEnumerator Temporise(float timer, GameObject bulletPrefab, Transform firePoint, Shooting shooter)
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
            yield return new WaitForSecondsRealtime(timer);
        }
        
    }
}
