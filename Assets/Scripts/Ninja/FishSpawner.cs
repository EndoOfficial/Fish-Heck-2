using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    private int fishindex;
    public GameObject[] fishPrefab;

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
        GameEvents.Pause += Pause;
        GameEvents.Resume += Resume;
        GameEvents.TutorialStart += TutorialStart;
        GameEvents.TutorialStop += TutorialStop;
    }

    private void OnDisable()
    {
        GameEvents.GameOver -= GameOver;
        GameEvents.Pause -= Pause;
        GameEvents.Resume -= Resume;
        GameEvents.TutorialStart -= TutorialStart;
        GameEvents.TutorialStop -= TutorialStop;
    }

    private void TutorialStart()
    {
        StopAllCoroutines();
    }

    private void TutorialStop()
    {
        StartCoroutine(SpawnFish());
    }

    private void GameOver()
    {
        gameOver = true;
        StopAllCoroutines();
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

            //spawn fish
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            //choose which fish to spawn
            fishindex = Random.Range(0,fishPrefab.Length);
            Instantiate(fishPrefab[fishindex], spawnPoint.position, spawnPoint.rotation);            
        }
    }
}
