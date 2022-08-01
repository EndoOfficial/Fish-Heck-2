using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBaby : MonoBehaviour
{
    private int setScore = 15;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // send event for scoring
        if (other.gameObject.tag == "Player")
        {
            GameEvents.FishScore?.Invoke(setScore);
            Destroy(this.gameObject);
        }
        //trigger the crab aggro
    }
}
