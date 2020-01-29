using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string nextLevelName;
    public float timeToSurvive;
    public GameObject player;

    public void Start()
    {
        player = GetComponent<GetPlayer>().getPlayer();
    }
    public void FixedUpdate()
    {
        if (Time.time > timeToSurvive)
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
