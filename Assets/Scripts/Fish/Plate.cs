using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private int setScore;

    //move when existing
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.left * 1f, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FishLast"))
        {
            setScore = 1;
            GameEvents.FishScore?.Invoke(setScore);
            Destroy(other.gameObject);
        }
    }
}
