using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinSpawner : MonoBehaviour
{
    public GameObject Player;                   // spawn at player position if shark-free space not found

    public GameObject Platform;
    public GameObject Iceberg;
    public Coin Coin;                           // prefab
    private Coin currentCoin;

    // raycasting
    private float coinRadius;
    private float raycastSize = 1.5f;           // to allow space between
    private float rayCastHeight = 20f;
    public LayerMask hitLayerMask;              // for raycast hits of sharks (and player?)

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

        coinRadius = Coin.GetComponent<BoxCollider>().size.x;           // STEVE: assumes 'Coin' (sushi) has a BoxColllider!
        //coinRadius = Coin.GetComponent<SphereCollider>().radius;       // STEVE: if 'Coin' (sushi) has a SphereColllider
    }

    // find a position away from the sharks (and player)
    private Vector3 VacantRandomPosition()
    {
        RaycastHit hit;
        Vector3 randomPosition;
        int counter = 1000; //limit duplication

        do
        {
            randomPosition = RandomSpawnPosition;

            Vector3 rayCastOrigin = new Vector3(randomPosition.x, randomPosition.y + rayCastHeight, randomPosition.z);

            Physics.SphereCast(rayCastOrigin, coinRadius * raycastSize, Vector3.down, out hit, rayCastHeight * 2f, hitLayerMask);
            counter--;
        }
        while (counter > 0 && hit.transform != null);

        if (counter <= 0)
        {
            Debug.Log($"VacantRandomPosition: counter expired!!");
            return Player.transform.position;
        }

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
