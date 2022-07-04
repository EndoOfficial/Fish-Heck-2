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
    public Fish puffer;
    public Fish pufferHalf;
    public Fish pufferPoison;

    public bool canCut = false;
    public float graceTime = 0.5f;

    Rigidbody rb;
    public float startForce = 0f;

    private void OnEnable()
    {
        GameEvents.GameOver += GameOver;
    }

    private void OnDisable()
    {
        GameEvents.GameOver -= GameOver;
    }

    private void Start()
    {
        if (gameObject.CompareTag("BigFish"))
        {
            canCut = true;
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * -Random.Range(startForce -.5f, startForce +.5f), ForceMode.Impulse);
        }
        else if (gameObject.CompareTag("Pufferfish"))
        {
            canCut = true;
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * -Random.Range(startForce -.5f, startForce +.5f), ForceMode.Impulse);
        }
        else if (gameObject.CompareTag("FishHalf"))
        {
            StartCoroutine(Grace());
        }
        else if (gameObject.CompareTag("PufferPoison"))
        {
            StartCoroutine(Grace());
        }
    }

    //summon fish halves
    public void FishCut()
    {
        
        Fish newhead = Instantiate(fishHead, transform.position, transform.rotation);
        Fish newtail = Instantiate(fishTail, transform.position, transform.rotation);

        newhead.GetComponent<Rigidbody>().AddForce(Vector3.right * -Random.Range(1, 5), ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddForce(Vector3.left * -Random.Range(1, 5), ForceMode.Impulse);
        newhead.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(3, 6), ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(3, 6), ForceMode.Impulse);
        Destroy(this.gameObject);
        
    }

    //create sashimi
    public void HalfFishCut()
    { 
        if (fishLast1 != null)
        {
            Fish newLast1 = Instantiate(fishLast1, transform.position, transform.rotation);
            newLast1.GetComponent<Rigidbody>().AddForce(Vector3.right * Random.Range(1, 5), ForceMode.Impulse);
            newLast1.GetComponent<Rigidbody>().AddForce(Vector3.up * -Random.Range(3, 6), ForceMode.Impulse);
        }
        if (fishLast2 != null)
        {
            Fish newLast2 = Instantiate(fishLast2, transform.position, transform.rotation);
            newLast2.GetComponent<Rigidbody>().AddForce(Vector3.left * Random.Range(1, 5), ForceMode.Impulse);
            newLast2.GetComponent<Rigidbody>().AddForce(Vector3.up * -Random.Range(3, 6), ForceMode.Impulse);
        }
    }

    public void Puffercut()
    {
        // loop for a random number between -5 and 5
        // repeat if number is between -2 and 2
        float randomNumber;
        do
        {
            randomNumber = Random.Range(-5, 5);
        } while (randomNumber < 2 && randomNumber > -2);

        // instantiate halves in opposite directions
        Fish newPufferHalf = Instantiate(pufferHalf, transform.position, transform.rotation);
        Fish newPufferPoison = Instantiate(pufferPoison, transform.position, transform.rotation);
        newPufferHalf.GetComponent<Rigidbody>().AddForce(Vector3.left * randomNumber, ForceMode.Impulse);
        newPufferHalf.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(4, 6), ForceMode.Impulse);

        newPufferPoison.GetComponent<Rigidbody>().AddForce(Vector3.right * randomNumber, ForceMode.Impulse);
        newPufferPoison.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(4, 6), ForceMode.Impulse);
        
    }

    private void GameOver()
    {
        Destroy(this.gameObject);
    }

    //fish grace petiod
    private IEnumerator Grace()
    {
        canCut = false;
        yield return new WaitForSeconds(graceTime);
        canCut = true;
    }
}
