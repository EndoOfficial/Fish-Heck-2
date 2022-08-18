using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    Rigidbody rb;
    private int setScore;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.left * 1f, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        var thisfish = other.gameObject.transform.GetComponent<Fish>();
        if (other.CompareTag("BigFish") || other.CompareTag("BigFish2") || other.CompareTag("FishHalf") || other.CompareTag("Pufferfish") || other.CompareTag("PufferHalf") || other.CompareTag("FishLast") || other.CompareTag("Squid") || other.CompareTag("SquidHalf"))
        {
            //if fish is falling
            if (other.GetComponent<Rigidbody>().velocity.y < 0)
            {

            //if sashimi touches
            //add score and destroy
                if (thisfish != null)
                {
                    thisfish.onPlate = true;
                    thisfish.canCut = false;
                    other.attachedRigidbody.useGravity = false;
                    other.attachedRigidbody.velocity = Vector3.left * 1f;
                    other.attachedRigidbody.angularVelocity = Vector3.zero;
                }
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
            }
            
        }
    }
}