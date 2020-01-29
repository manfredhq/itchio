using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI weaponNameText;

    private void Start()
    {
        levelText.text = "Level: " + player.GetComponent<Player>().level;
        hpText.text = "Hp: " + player.GetComponent<Player>().hp;
        damageText.text = "Damage: " + player.GetComponent<Shooting>().damage;
        weaponNameText.text = "Weapon: " + player.GetComponent<Shooting>().weapon.GetComponent<IWeapon>().weaponName;
    }

    private void FixedUpdate()
    {
        levelText.text = "Level: " + player.GetComponent<Player>().level;
        hpText.text = "Hp: " + player.GetComponent<Player>().hp;
        damageText.text = "Damage: " + player.GetComponent<Shooting>().damage;
        weaponNameText.text = "Weapon: " + player.GetComponent<Shooting>().weapon.GetComponent<IWeapon>().weaponName;
    }
}
