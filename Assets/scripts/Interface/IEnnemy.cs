using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnnemy
{


    List<GameObject> loot { get; set; }
    Transform player { get; set; }
    float moveSpeed { get; set; }
    Rigidbody2D rb { get; set; }
    Vector2 movement { get; set; }

    int hp { get; set; }
    int damage { get; set; }
    int xpDrop { get; set; }

    void TakeDamage(float damage);
    void ScaleStats(int scaleValue);
    void Die();
}
