using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFish : MonoBehaviour
{
    private int setScore = 0;
    private void OnTriggerEnter(Collider other)
    {
        var fish = other.GetComponent<Fish>();
        
        if (fish != null)
        {
            if (other.CompareTag("BigFish"))
            {
                GameEvents.LoseLife?.Invoke();
            }
            else if (other.CompareTag("Pufferfish"))
            {
                GameEvents.LoseLife?.Invoke();
            }
            else if (other.CompareTag("PufferPoison"))
            {
                setScore = 5;
                GameEvents.FishScore?.Invoke(setScore);
            }
            Destroy(other.gameObject);
        }
    }
}
