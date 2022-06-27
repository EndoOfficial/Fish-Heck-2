using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Platform;
    public GameObject Iceberg;
    public Coin Coin;
    private Coin currentCoin;
    private Vector3 playArea;
    private float coinRadius;
    private float raycastSize = 1.5f;
    public LayerMask hitLayerMask;
    private int activeCoin;
    public int MaxCoins = 5;

    private float widthx = 0;
    private float widthy = 0;
    private float widthz = 0;
    
    private Vector3 RandomSpawnPosition => new Vector3(UnityEngine.Random.Range(Platform.transform.position.x - (widthx/2f),
                                                                                Platform.transform.position.x + (widthx / 2f)),
                                                                                 (Platform.transform.position.y + 1),
                                                                            UnityEngine.Random.Range(Platform.transform.position.z - (widthz / 2f),
                                                                                    Platform.transform.position.z + (widthz / 2f)));

    private void OnEnable()
    {
        GameEvents.CoinScore += SpawnCoin;
        GameEvents.CoinEat += SpawnCoin;
    }
    private void OnDisable()
    {
        GameEvents.CoinScore -= SpawnCoin;
        GameEvents.CoinEat -= SpawnCoin;
    }
    private void Start()
    {
        widthx = Platform.transform.localScale.x;
        widthy = Platform.transform.localScale.y;
        widthz = Platform.transform.localScale.z;
    }
    private Vector3 VacantRandomPosition()
    {
        RaycastHit hit;
        Vector3 randomPosition;
        int counter = 100; //limit duplication

        do
        {
            randomPosition = RandomSpawnPosition;

            Vector3 rayCastOrigin = new Vector3(randomPosition.x, randomPosition.y + 100, randomPosition.z);

            Physics.SphereCast(rayCastOrigin, coinRadius * raycastSize, Vector3.down, out hit, 200f, hitLayerMask);
            counter--;
        }
        while (counter > 0 && hit.transform != null);
        return randomPosition;
        
    }
    private void SpawnCoin()
    {
      
            currentCoin = Instantiate(Coin, transform);
            currentCoin.transform.position = VacantRandomPosition();

    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(Platform.transform.position, new Vector3(widthx, widthy, widthz));
    }

}
