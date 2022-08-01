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

    private int nCount = 10;
    private int sCount = 5;

    public GameObject Whale;
    public GameObject jellyPrefab;
    public GameObject smallJellyPrefab;
    public GameObject fakeJellyPrefab;

    private float jellyMoveCount;
    private float smallJellyMoveCount;

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
        if (jellyMoveCount >= nCount)
        {
            Destroy(obj.gameObject);
            jellyMoveCount = 0;
            nCount--;
            if (nCount < 4)
            {
                nCount = 4;
            }
        }
        else
        {
            obj.transform.position = spawnPosition;
            jellyMoveCount++;
        }
    }
    private void SmallJellyMove(Collider obj)
    {
        //small jellyfish
        smallSpawnPosition.y += Random.Range(2f, 5f);
        smallSpawnPosition.x = Random.Range(-8f, 8f);
        if (smallJellyMoveCount >= sCount)
        {
            Destroy(obj.gameObject);
            smallJellyMoveCount = 0;
            sCount--;
            if(sCount < 2)
            {
                sCount = 2;
            }
        }
        else
        {
        obj.transform.position = smallSpawnPosition;
        smallJellyMoveCount++;
        }
        
    }
}
