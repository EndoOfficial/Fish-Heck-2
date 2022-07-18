using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinSpawner : MonoBehaviour
{
    public GameObject Player;                   // spawn at player position if shark-free space not found

    public GameObject Platform;                 //the area that the raycast is spawning to 
    public GameObject Iceberg;                  //the physical object of the platform that the sushi/coin spawns on
    public Coin Coin;                           // prefab
    private Coin currentCoin;                   // the current existing sushi/coin

    // raycasting
    private float coinRadius;                   // The size of the space that the raycast needs to find a place for
    private float raycastSize = 1.5f;             // to allow space between
    private float rayCastHeight = 20f;

    public LayerMask hitLayerMask;              // for raycast hits of sharks (STEVE: and player and sushi?)
    public LayerMask spawnLayerMask;            // STEVE: for final raycast hit on platform, to spawn sushi/coin

    private float widthx = 0;
    private float widthy = 0;
    private float widthz = 0;

    //setting the location that the raycast is searching through
    private Vector3 RandomSpawnPosition => new Vector3(UnityEngine.Random.Range(Platform.transform.position.x - (widthx / 2f),
                                                                                    Platform.transform.position.x + (widthx / 2f)),
                                                            (Platform.transform.position.y + 1),
                                                            UnityEngine.Random.Range(Platform.transform.position.z - (widthz / 2f),
                                                                                    Platform.transform.position.z + (widthz / 2f)));

    private void OnEnable()
    {
        GameEvents.FishScore += SpawnCoin;
        GameEvents.SharkEat += SpawnCoin;
    }
    private void OnDisable()
    {
        GameEvents.FishScore -= SpawnCoin;
        GameEvents.SharkEat -= SpawnCoin;
    }

    private void Start()
    {
        widthx = Platform.transform.localScale.x;
        widthy = Platform.transform.localScale.y;
        widthz = Platform.transform.localScale.z;

        // sets the radius of the sushi
        coinRadius = Coin.GetComponent<BoxCollider>().size.x;           // STEVE: assumes 'Coin' (sushi) has a BoxColllider!
        //coinRadius = Coin.GetComponent<SphereCollider>().radius;       // STEVE: if 'Coin' (sushi) has a SphereColllider
    }

    // find a position away from the sharks (and player)
    private Vector3 VacantRandomPosition()
    {
        RaycastHit hit;
        Vector3 randomPosition;
        Vector3 rayCastOrigin;

        int counter = 10000; //checks for a spot to spawn 1000 times before falling back on the contingency 

        do
        {   // finds a new place to spawn
            randomPosition = RandomSpawnPosition;

            rayCastOrigin = new Vector3(randomPosition.x, randomPosition.y + rayCastHeight, randomPosition.z);

            Physics.SphereCast(rayCastOrigin, coinRadius * raycastSize, Vector3.down, out hit, rayCastHeight * 2f, hitLayerMask);
            counter--;
        }
        while (counter > 0 && hit.transform != null);

        if (counter <= 0)
        {   // if the rayast cant find a spot within 1000 attempts, it will spawn on the player to prevent it spawning in an unreachable place
            Debug.Log($"VacantRandomPosition: counter expired!!");
            return Player.transform.position;
        }

        // STEVE
        // vacant space found, use 'successful' rayCastOrigin to raycast onto iceberg
        // which may have rotated during the raycast loop,
        // so raycast again to get exact spawn point on the iceberg's box collider (not colliders of child objects)
        RaycastHit spawnHit;
        Physics.Raycast(rayCastOrigin, Vector3.down, out spawnHit, rayCastHeight * 2f, spawnLayerMask);
        Debug.Log("position" + spawnHit.transform.position);
        return spawnHit.point;
        //return randomPosition;
    }

    private void SpawnCoin(int setScore)
    {
        currentCoin = Instantiate(Coin, Iceberg.transform); //parents coin to platform
        var coinPosition = VacantRandomPosition();
        coinPosition = new Vector3(coinPosition.x, coinPosition.y + 1f, coinPosition.z); //moves the coin up a smidge

        currentCoin.transform.position = coinPosition;

        currentCoin.transform.localScale = new Vector3(0.13f, 0.13f, 0.13f);
    }

    private void OnDrawGizmos() // to see the spawn area
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(Platform.transform.position, new Vector3(widthx, widthy, widthz));
    }
}   