using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnnemy
{


    public List<GameObject> loot { get; set; }
    public Transform player { get; set; }
    public float moveSpeed { get; set; }
    public Rigidbody2D rb { get; set; }
    public Vector2 movement { get; set; }

    public int hp { get; set; }
    public int damage { get; set; }
    public int xpDrop { get; set; }

    void TakeDamage(float damage);
    void ScaleStats(int scaleValue);
    void Die();
}
