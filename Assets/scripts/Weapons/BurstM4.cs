using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstM4 : MonoBehaviour, IWeapon
{
    public int damage;
    public float bulletForce;
    public float RPM;
    public WeaponType weaponType = WeaponType.pistol;


    // Start is called before the first frame update

    public void Setup(float rpm = 0.5f, int dmg = 1, int bullet = 1, float bulletSpeed = 20f)
    {
        RPM = rpm;
        damage = dmg;
        bulletForce = bulletSpeed;
        weaponType = WeaponType.pistol;
    }
    public void Shoot(GameObject bulletPrefab, Transform firePoint)
    {
        
        StartCoroutine(Temporise(RPM, bulletPrefab, firePoint));
        
    }

    IEnumerator Temporise(float timer, GameObject bulletPrefab, Transform firePoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bul = bullet.GetComponent<Bullet>();
        if (bul != null)
        {
            bul.damage = damage;
        }
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        yield return new WaitForSecondsRealtime(timer);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bul2 = bullet2.GetComponent<Bullet>();
        if (bul2 != null)
        {
            bul2.damage = damage;
        }
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
