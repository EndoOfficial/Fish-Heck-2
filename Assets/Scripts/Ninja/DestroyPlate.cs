using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlate : MonoBehaviour
{
    private int setScore;
    //destroy plate on trigger enter
    private void OnTriggerEnter(Collider other)
    {
        var fish = other.GetComponent<Fish>();
        if (other.tag == "FishLast")
        {
            if (fish.poisoned)
            {
                setScore = -1;
                GameEvents.FishScore?.Invoke(setScore);
            }

            else
            {
                setScore = 1;
                GameEvents.FishScore?.Invoke(setScore);
            }
        }

        else if (other.tag == "BigFish")
        {
            GameEvents.LoseLife?.Invoke();
        } 
        else if (other.tag == "BigFish2")
        {
            GameEvents.LoseLife?.Invoke();
        }
        else if (other.tag == "Squid")
        {
            GameEvents.LoseLife?.Invoke();
        }
        else if (other.tag == "SquidHalf")
        {
            setScore = -2;
            GameEvents.FishScore?.Invoke(setScore);
        }
        else if (other.tag == "FishHalf")
        {
            setScore = -3;
            GameEvents.FishScore?.Invoke(setScore);
        }

        else if (other.tag == "PufferFish")
        {
            setScore = -4;
            GameEvents.FishScore?.Invoke(setScore);
            GameEvents.LoseLife?.Invoke();
        }
        Destroy(other.gameObject, 1f);
    }
}

