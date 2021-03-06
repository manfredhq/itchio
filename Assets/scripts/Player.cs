﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;

    public List<GameObject> weaponList;

    public float TimeInvulnerability = 3f;
    private float NextTimeCanBeHitted = 0f;

    public Rigidbody2D rb;
    public Camera cam;

    private Vector2 movement;
    private Vector2 mousePos;

    public int hp;
    public int level = 1;
    public int xpToNextLevel = 1;
    public int actualXp = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
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
        SceneManager.LoadScene("Level1");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IBonus bonus = collision.gameObject.GetComponent<IBonus>();
        if (bonus != null)
        {
            bonus.makeAction(this);
            Destroy(collision.gameObject);
        }
        IWeapon weapon = collision.gameObject.GetComponent<IWeapon>();
        if (weapon != null)
        {
            GameObject newWeapon = Instantiate(collision.gameObject, new Vector3(10000,10000,-1000), Quaternion.identity);
            newWeapon.GetComponent<SpriteRenderer>().sprite = null;
            newWeapon.AddComponent<NoDestroy>();
            GetComponent<Shooting>().weapon = newWeapon;


        }
        Destroy(collision.gameObject);
    }

    public void GainXp(int amount)
    {
        actualXp += amount;
        while(actualXp > xpToNextLevel)
        {
            level++;
            actualXp -= xpToNextLevel;
            GetComponent<Shooting>().damage++;
            GetComponent<Shooting>().RPM -= level / 100;
            hp += level;
            xpToNextLevel = level * level;
        }
        //todo
    }
}
