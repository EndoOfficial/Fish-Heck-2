using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleSuck : MonoBehaviour
{
    public float speed;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Jellyfish"))
        {
            var step = speed * Time.deltaTime;
            other.transform.position = Vector3.MoveTowards(other.transform.position, transform.parent.position, step);
        }
        else if (other.CompareTag("Jellyfish2"))
        {
            var step = speed * Time.deltaTime;
            other.transform.position = Vector3.MoveTowards(other.transform.position, transform.parent.position, step);
        }
    }
}
