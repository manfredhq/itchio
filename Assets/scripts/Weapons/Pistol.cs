using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    public int damage { get => damage; set => damage = value; }
    public float bulletForce { get => bulletForce; set => bulletForce = value; }
    public float RPM { get => RPM; set => RPM = value; }
    public WeaponType weaponType { get => weaponType; set => weaponType = value; }


    // Start is called before the first frame update
    void Start(float rpm = 0.5f, int dmg = 1, float bulletSpeed = 20f)
    {
        RPM = rpm;
        damage = dmg;
        bulletForce = bulletSpeed;
        weaponType = WeaponType.pistol;
    }
}
