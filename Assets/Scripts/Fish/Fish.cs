using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public Fish fishHead;
    public Fish fishTail;
       
    public void FishCut()
    {
        Fish newhead = Instantiate(fishHead, transform.position, transform.rotation);
        Fish newtail = Instantiate(fishTail, transform.position, transform.rotation);
        newhead.GetComponent<Rigidbody>().AddForce(Vector3.left*2f, ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddForce(Vector3.right * 2f, ForceMode.Impulse);
        newhead.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }
}
