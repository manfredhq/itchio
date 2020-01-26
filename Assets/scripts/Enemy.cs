using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<GameObject> loot;
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public int hp;
    public int damage = 1;
    public int xpDrop = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        //moveCharacter(movement);
    }
    /*void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        //player.gameObject.GetComponent<Rigidbody2D>().AddForce((transform.position + player.transform.position) * 150000, ForceMode2D.Impulse);
    }

    public void TakeDamage(int damage)
    {
        hp = hp - damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        player.gameObject.GetComponent<Player>().GainXp(xpDrop);
        Destroy(gameObject);
    }
}
