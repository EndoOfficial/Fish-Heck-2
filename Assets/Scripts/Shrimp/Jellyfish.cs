using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shrimp")
        {
            rb = other.GetComponent<Rigidbody>();
            rb.AddForce(other.transform.up * 1, ForceMode.Impulse);
        }
    }
}
