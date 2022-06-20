using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public Fish mainFish;
    public Fish fishHead;
    public Fish fishTail;
    public Fish fishLast1;
    public Fish fishLast2;
    public bool canCut = false;
    public float graceTime = 0.5f;

    private void Start()
    {
        if (gameObject.CompareTag("BigFish"))
        {
            canCut = true;
        }
        else if (gameObject.CompareTag("FishHalf"))
        {
            StartCoroutine(Grace());
        }
    }
    //summon fish halves
    public void FishCut()
    {
        Instantiate(mainFish, GameObject.Find("FishSpawner").transform.position, GameObject.Find("FishSpawner").transform.rotation);
        Fish newhead = Instantiate(fishHead, transform.position, transform.rotation);
        Fish newtail = Instantiate(fishTail, transform.position, transform.rotation);

        newhead.GetComponent<Rigidbody>().AddForce(Vector3.right*2f, ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddForce(Vector3.left * 2f, ForceMode.Impulse);
        newhead.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }
    //create sashimi
    public void HalfFishCut()
    {
        Debug.Log("half cut");
        if (fishLast1 != null)
        {
            Fish newLast1 = Instantiate(fishLast1, transform.position, transform.rotation);
            newLast1.GetComponent<Rigidbody>().AddForce(Vector3.right * 2f, ForceMode.Impulse);
            newLast1.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
        if (fishLast2 != null)
        {
            Fish newLast2 = Instantiate(fishLast2, transform.position, transform.rotation);
            newLast2.GetComponent<Rigidbody>().AddForce(Vector3.left * 2f, ForceMode.Impulse);
            newLast2.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }
    //fish grace petiod
    private IEnumerator Grace()
    {
        canCut = false;
        Debug.Log($"canCut = false {name}");
        yield return new WaitForSeconds(graceTime);
        canCut = true;
        Debug.Log($"canCut = true {name}");
    }
}
