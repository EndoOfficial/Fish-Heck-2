using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject pufferPrefab;
    public Transform[] spawnPoints;

    public float minDelay = .1f;
    public float maxDelay = 1f;
    private bool gameOver = false;
    
    public float pufferChance;
    public float tunaChance;

    private void Start()
    {
        StartCoroutine(SpawnFish());
    }

    private void OnEnable()
    {
        GameEvents.GameOver += GameOver;
        GameEvents.Difficulty += Difficulty;
        GameEvents.Pause += Pause;
        GameEvents.Resume += Resume;
    }
    private void OnDisable()
    {
        GameEvents.GameOver -= GameOver;
        GameEvents.Difficulty -= Difficulty;
        GameEvents.Pause -= Pause;
        GameEvents.Resume -= Resume;
    }

    private void GameOver()
    {
        gameOver = true;
        StopAllCoroutines();
    }

    private void Difficulty()
    {
        maxDelay = maxDelay * 0.9f;

    }

    private void Pause()
    {
        StopAllCoroutines();
    }
    

    private void Resume()
    {
        StartCoroutine(SpawnFish());
    }

    IEnumerator SpawnFish()
    {
        while (gameOver == false)
        {
            // get a number from 0-99
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSecondsRealtime(delay);

            //if the random number is higher than the pufferchance
            if (Random.Range(0, 99) >= pufferChance && Random.Range(0, 99) >=  tunaChance) 
            {

                //spawn fish
                int spawnIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[spawnIndex];

                Instantiate(fishPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            else
            {
                //spawn pufferfish
                int spawnIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[spawnIndex];

                Instantiate(pufferPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
