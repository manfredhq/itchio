using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpup : MonoBehaviour, IBonus
{
    void IBonus.makeAction(Player player)
    {
        player.Heal(3);
    }
}
