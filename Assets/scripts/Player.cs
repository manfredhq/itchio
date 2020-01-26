using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;

    public float TimeInvulnerability = 3f;
    private float NextTimeCanBeHitted = 0f;

    public Rigidbody2D rb;
    public Camera cam;

    private Vector2 movement;
    private Vector2 mousePos;

    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x= Input.GetAxisRaw("Horizontal");
        movement.y= Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }


    public void Heal(int amount)
    {
        hp += amount;
    }
    public void TakeDamage(int damage)
    {
        if (NextTimeCanBeHitted < Time.time)
        {
            Debug.Log("test");
            hp -= damage;
            NextTimeCanBeHitted = Time.time + TimeInvulnerability;
            if (hp <= 0)
            {
                Die();
            }
        }
        else { 
            Debug.Log("Invincible");
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IBonus bonus = collision.gameObject.GetComponent<IBonus>();
        if (bonus != null)
        {
            bonus.makeAction(this);
            Destroy(collision.gameObject);
        }
    }
}
