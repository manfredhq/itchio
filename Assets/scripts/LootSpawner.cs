using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    public List<GameObject> loot;

    public float TimeBetweenSpawn = 15f;
    public float NextSpawnTime = 0f;

    private GameObject SpawnedItem = null;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        if (NextSpawnTime < Time.time && SpawnedItem == null)
        {
            int random = Random.Range(0, loot.Count);
            SpawnedItem = Instantiate(loot[random], new Vector3(transform.position.x, transform.position.y, transform.position.z -1), Quaternion.identity);
            NextSpawnTime = Time.time + TimeBetweenSpawn;
            //spawn the bonus
        }
    }
}
