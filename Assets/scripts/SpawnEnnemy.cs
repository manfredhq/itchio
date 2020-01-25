using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnnemy : MonoBehaviour
{

    public List<Enemy> enemies;
    public Transform target;

    public float WaitTimeBetweenSpawn = 2f;
    public int SpawnAtATime = 1;

    private float NextTimeToSpawn = 0f;
    // Start is called before the first frame update
    private void Start()
    {
        NextTimeToSpawn += WaitTimeBetweenSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (NextTimeToSpawn <= Time.time)
        {
            NextTimeToSpawn = Time.time + WaitTimeBetweenSpawn;
            Spawn();
        }
    }

    private void Spawn()
    {
        
        for (int i = 0; i < SpawnAtATime; i++)
        {
            Enemy enemy = Instantiate(enemies[Random.Range(0, enemies.Count)],transform.position, Quaternion.identity);
            enemy.GetComponent<Enemy>().player = target;
            enemy.gameObject.name = "enemy";
        }
        
    }
}
