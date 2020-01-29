using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
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
        player = GetComponent<GetPlayer>().getPlayer().transform;
        GetComponent<AIDestinationSetter>().target = GetComponent<GetPlayer>().getPlayer().transform;
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

    public void TakeDamage(float damage)
    {
        hp = hp - (int)damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    public void ScaleStats(int scaleValue)
    {
        hp *= scaleValue;
        damage *= scaleValue;
    }
    private void Die()
    {
        float rng = Random.Range(0f, 100f);
        if (rng < 5)
        {
            Debug.Log("LOOT");
            var weaponDrop = Instantiate(loot[Random.Range(0, loot.Count)],transform.position, Quaternion.identity);
            IWeapon weapon = weaponDrop.GetComponent<IWeapon>();
            float randomRpm = Random.Range(weapon.RPM - weapon.RPM / 10, weapon.RPM + weapon.RPM / 10);
            float randomDamage = Random.Range(weapon.damage - weapon.damage / 10, weapon.damage + weapon.damage / 10);
            int randomBullet = 1;
            if (weapon.weaponType == WeaponType.burstM4)
            {
                randomBullet = Random.Range(weapon.nbBullet - 1, weapon.nbBullet + 2);
            }
            float randomBulletSpeed = Random.Range(weapon.bulletForce - weapon.bulletForce / 10, weapon.bulletForce + weapon.bulletForce / 10);
            weapon.Setup(randomRpm,randomDamage,randomBullet,randomBulletSpeed);
        }
        player.gameObject.GetComponent<Player>().GainXp(xpDrop);
        Destroy(gameObject);
    }
}
