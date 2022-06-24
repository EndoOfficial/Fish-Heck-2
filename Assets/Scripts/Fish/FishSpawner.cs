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
        GameEvents.Difficulty += Difficulty;

    }
    private void OnDisable()
    {
        GameEvents.GameOver -= GameOver;
        GameEvents.Difficulty += Difficulty;
    }

    private void GameOver()
    {
        StopAllCoroutines();
    }

    private void Difficulty()
    {
        maxDelay = maxDelay * 0.9f;

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
