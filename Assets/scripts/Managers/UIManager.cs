using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI hpText;

    private void Start()
    {
        levelText.text = "Level: " + player.GetComponent<Player>().level;
        hpText.text = "Hp: " + player.GetComponent<Player>().hp;
    }

    private void FixedUpdate()
    {
        levelText.text = "Level: " + player.GetComponent<Player>().level;
        hpText.text = "Hp: " + player.GetComponent<Player>().hp;
    }
}
