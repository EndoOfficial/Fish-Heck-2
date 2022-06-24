using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public Transform[] spawnPoints;

    public float minDelay = .1f;
    public float maxDelay = 1f;
    private bool gameOver = false;
    private void Start()
    {
        StartCoroutine(SpawnFish());
    }

    private void OnEnable()
    {
        GameEvents.GameOver += GameOver;
    }
    private void OnDisable()
    {
        GameEvents.GameOver -= GameOver;
    }

    private void GameOver()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnFish()
    {
        while (gameOver == false)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSecondsRealtime(delay);
            
            //spawn fish
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            Instantiate(fishPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
