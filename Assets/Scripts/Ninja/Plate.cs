using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    Rigidbody rb;

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
            }
        }
    }
}