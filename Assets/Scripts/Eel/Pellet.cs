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
            GameEvents.FishScore?.Invoke(setScore);
            this.gameObject.SetActive(false);
        }
    }
}
