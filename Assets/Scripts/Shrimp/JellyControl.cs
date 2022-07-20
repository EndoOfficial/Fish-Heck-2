using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyControl : MonoBehaviour
{
    public int jellyCount;
    public int count;
    public float minDist;
    public float maxDist;
    public Vector2 spawnPosition;
    public Vector2 falseSpawnPosition;

    public GameObject Whale;
    public GameObject jellyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (count = 0; count < jellyCount; count++)
        {
            spawnPosition.y += Random.Range(minDist, maxDist);
            spawnPosition.x = Random.Range(-8f, 8f);
            Instantiate(jellyPrefab, spawnPosition, Quaternion.identity);
        }
    }
    private void OnEnable()
    {
        GameEvents.JellyDestroy += JellyDestroy;
    }
    private void OnDisable()
    {
        GameEvents.JellyDestroy -= JellyDestroy;
    }

    private void JellyDestroy()
    {
        spawnPosition.y += Random.Range(minDist, maxDist);
        spawnPosition.x = Random.Range(-8f, 8f);
        Instantiate(jellyPrefab, spawnPosition, Quaternion.identity);
    }
}
