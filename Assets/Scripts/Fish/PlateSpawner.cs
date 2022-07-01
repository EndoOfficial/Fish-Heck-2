using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    public GameObject plate;
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlateSpawn());
    }  

    IEnumerator PlateSpawn()
    {
        //repeat forever
        while (gameOver == false)
        {
            // spawn plates every second
            Instantiate(plate, transform.position, transform.rotation);
            yield return new WaitForSeconds(1f);
        }
    }
}
