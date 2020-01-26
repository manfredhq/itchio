using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    string name { get; set; }
    int damage { get; set; }
    
    float bulletForce { get; set; } 
    float RPM { get; set; }

    public WeaponType weaponType { get; set; }
}
public enum WeaponType
{
    pistol,
    shotgun
}