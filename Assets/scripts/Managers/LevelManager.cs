using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string nextLevelName;
    public float timeToSurvive;
    public GameObject player;
    public GameObject SpawnPoint;
    private float timeToSurviveScaled;

    public void Start()
    {
        timeToSurviveScaled = Time.time + timeToSurvive;
        player = GetComponent<GetPlayer>().getPlayer();
        player.transform.position = SpawnPoint.transform.position;
    }
    public void FixedUpdate()
    {
        if (Time.time > timeToSurviveScaled)
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
