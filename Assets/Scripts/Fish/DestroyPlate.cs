using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlate : MonoBehaviour
{

    //destroy plate on trigger enter
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plate")
        {
            Destroy(other.gameObject);
        }
    }
}
