using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    public GameObject plate;
    private bool forever = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlateSpawn());
    }

    private void OnEnable()
    {
        GameEvents.Pause += Pause;
        GameEvents.Resume += Resume;
    }

    private void OnDisable()
    {
        GameEvents.Pause -= Pause;
        GameEvents.Resume -= Resume;
    }

    private void Pause()
    {
        StopAllCoroutines();
    }

    private void Resume()
    {
        StartCoroutine(PlateSpawn());
    }



    IEnumerator PlateSpawn()
    {
        //repeat forever even after gameover
        while (forever == false)
        {
            // spawn plates every second
            Instantiate(plate, transform.position, transform.rotation);
            yield return new WaitForSecondsRealtime(.9f);
        }
    }
}
