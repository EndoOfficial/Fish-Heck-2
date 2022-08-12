using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBaby : MonoBehaviour
{
    private int setScore = 15;
    public GameObject crab;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // send event for scoring
        //spawn crab
        if (other.gameObject.tag == "Player")
        {
            GameEvents.FishScore?.Invoke(setScore);
            GameEvents.CrabSpawn?.Invoke();
            Destroy(this.gameObject);
        }
        //trigger the crab aggro
    }
}
