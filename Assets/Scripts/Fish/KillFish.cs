using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFish : MonoBehaviour
{
    private float big = 10;
    private float small = 5;
    private void OnTriggerEnter(Collider other)
    {
        var fish = other.GetComponent<Fish>();
        
        if (fish != null)
        {
            if (other.CompareTag("BigFish"))
            {
                GameEvents.LoseScore?.Invoke();
                GameEvents.GameOver?.Invoke();
            }
            else if (other.CompareTag("FishHalf"))
            {
                GameEvents.LoseScore?.Invoke();
            }
            else if (other.CompareTag("FishLast"))
            {
                GameEvents.FishScore?.Invoke();
            }
            Destroy(other.gameObject);
        }
    }
}
