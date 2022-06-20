using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFish : MonoBehaviour
{
    private int big = 10;
    private int small = 5;
    private void OnTriggerEnter(Collider other)
    {
        var fish = other.GetComponent<Fish>();
        
        if (fish != null)
        {
            if (other.CompareTag("BigFish"))
            {
                GameEvents.LoseScore?.Invoke(big);
                GameEvents.GameOver?.Invoke();
            }
            else if (other.CompareTag("FishHalf"))
            {
                GameEvents.LoseScore?.Invoke(small);
            }
            else if (other.CompareTag("FishLast"))
            {
                GameEvents.FishScore?.Invoke();
            }
            Destroy(other.gameObject);
        }
    }
}
