using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private int setScore = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // send event for scoring
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            this.gameObject.SetActive(false); //turn off the object
            GameEvents.FishScore?.Invoke(setScore); //scoring
            GameEvents.PelletCheck?.Invoke(); //checking if the pellets need to be reset
            
        }
    }
}
