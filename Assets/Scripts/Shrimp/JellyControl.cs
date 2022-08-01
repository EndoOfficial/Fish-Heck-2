using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyControl : MonoBehaviour
{
    public int jellyCount;
    public int falseJellyCount;
    public int count;
    public float minDist;
    public float maxDist;
    public Vector2 spawnPosition;
    public Vector2 smallSpawnPosition;

    public GameObject Whale;
    public GameObject jellyPrefab;
    public GameObject smallJellyPrefab;
    public GameObject fakeJellyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (count = 0; count < jellyCount; count++)
        {
            //normal jellyfish
            spawnPosition.y += Random.Range(minDist, maxDist);
            spawnPosition.x = Random.Range(-8f, 8f);
            Instantiate(jellyPrefab, spawnPosition, Quaternion.identity);

            //small jellyfish
            smallSpawnPosition.y += Random.Range(5f, 10f);
            smallSpawnPosition.x = Random.Range(-8f, 8f);
            Instantiate(smallJellyPrefab, smallSpawnPosition, Quaternion.identity);
        }
    }
    private void OnEnable()
    {
        GameEvents.JellyMove += JellyMove;
        GameEvents.SmallJellyMove += SmallJellyMove;
    }
    private void OnDisable()
    {
        GameEvents.JellyMove -= JellyMove;
        GameEvents.SmallJellyMove -= SmallJellyMove;
    }

    private void JellyMove(Collider obj)
    {
        //normal jellyfish
        spawnPosition.y += Random.Range(minDist, maxDist);
        spawnPosition.x = Random.Range(-8f, 8f);
        obj.transform.position = spawnPosition;
    }
    private void SmallJellyMove(Collider obj)
    {
        //small jellyfish
        smallSpawnPosition.y += Random.Range(2f, 15f);
        smallSpawnPosition.x = Random.Range(-8f, 8f);
        obj.transform.position = smallSpawnPosition;
    }
}
