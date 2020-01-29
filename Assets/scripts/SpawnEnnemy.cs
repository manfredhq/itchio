using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class SpawnEnnemy : MonoBehaviour
{
    public GameObject ennemieContainer;
    public List<GameObject> enemies;
    public Transform target;

    public float WaitTimeBetweenSpawn = 2f;
    public int SpawnAtATime = 1;

    private int RoundToAugmentSpawning = 2;

    private float NextTimeToSpawn = 0f;
    // Start is called before the first frame update
    private void Start()
    {
        target = GetComponent<GetPlayer>().getPlayer().transform;
        NextTimeToSpawn += WaitTimeBetweenSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (RoundToAugmentSpawning <= 0)
        {
            SpawnAtATime++;
            RoundToAugmentSpawning = 3;
        }
        if (NextTimeToSpawn <= Time.time)
        {
            NextTimeToSpawn = Time.time + WaitTimeBetweenSpawn;
            Spawn();
        }
    }

    private void Spawn()
    {
        RoundToAugmentSpawning--;
        for (int i = 0; i < SpawnAtATime; i++)
        {
            GameObject ennemyGO = Instantiate(enemies[Random.Range(0, enemies.Count)],transform.position, Quaternion.identity);
            IEnnemy enemy = ennemyGO.GetComponent<IEnnemy>();
            enemy.ScaleStats(SpawnAtATime);
            ennemyGO.gameObject.transform.SetParent(ennemieContainer.transform);
            enemy.player = target;
            ennemyGO.GetComponent<AIDestinationSetter>().target = target;
            ennemyGO.name = "enemy";
        }
        
    }
}
