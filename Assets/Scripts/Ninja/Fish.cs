using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    //list of fish prefabs
    public Fish[] fishIndex;

    //grace period variables
    public bool canCut = false;
    public float graceTime = 0.5f;

    Rigidbody rb;
    public float startForce;

    public bool poisoned = false;
    private Renderer rend;
    private Color fishcolor = Color.green;

    public bool onPlate = false;

    private void OnEnable()
    {
        GameEvents.GameOver += GameOver;
        GameEvents.Poison += Poison;
    }

    private void OnDisable()
    {
        GameEvents.GameOver -= GameOver;
        GameEvents.Poison -= Poison;
    }


    private void Start()
    {
        rend = GetComponent<Renderer>();
        if (gameObject.CompareTag("BigFish"))
        {
            canCut = true;
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * -Random.Range(startForce -.5f, startForce +.5f), ForceMode.Impulse);
        }
        else if (gameObject.CompareTag("BigFish2"))
        {
            canCut = true;
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * -Random.Range(startForce - .5f, startForce + .5f), ForceMode.Impulse);
        }
        else if (gameObject.CompareTag("Squid"))
        {
            canCut = true;
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * -Random.Range(startForce - .5f, startForce + .5f), ForceMode.Impulse);
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
        else if (gameObject.CompareTag("PufferHalf"))
        {
            StartCoroutine(Grace());
        }
        else if (gameObject.CompareTag("SquidHalf"))
        {
            StartCoroutine(Grace());
        }
        else if (gameObject.CompareTag("FishLast"))
        {
            canCut = false;
        }
    }

    //summon fish halves
    public void FishCut()
    {
        
        Fish newhead = Instantiate(fishIndex[1], transform.position = new Vector3(transform.position.x + -0.5f, transform.position.y, transform.position.z), transform.rotation);
        Fish newtail = Instantiate(fishIndex[2], transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.rotation);

        newhead.GetComponent<Rigidbody>().AddForce(Vector3.right * -Random.Range(1, 5), ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddForce(Vector3.left * -Random.Range(1, 5), ForceMode.Impulse);
        newhead.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(3, 6), ForceMode.Impulse);
        newhead.GetComponent<Rigidbody>().AddTorque(Vector3.forward * Random.Range(2, 3), ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(3, 6), ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddTorque(Vector3.forward * -Random.Range(2, 3), ForceMode.Impulse);

    }

    public void FishCut2()
    {
        Fish newhead = Instantiate(fishIndex[1], transform.position, transform.rotation);
        Fish newtail = Instantiate(fishIndex[2], transform.position, transform.rotation);

        newhead.GetComponent<Rigidbody>().AddForce(Vector3.right * -Random.Range(1, 5), ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddForce(Vector3.left * -Random.Range(1, 5), ForceMode.Impulse);
        newhead.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(3, 6), ForceMode.Impulse);
        newhead.GetComponent<Rigidbody>().AddTorque(Vector3.forward * Random.Range(2, 3), ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(3, 6), ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddTorque(Vector3.forward * -Random.Range(2, 3), ForceMode.Impulse);
    }
    public void SquidCut()
    {
        Fish newhead = Instantiate(fishIndex[1], transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.rotation);
        Fish newtail = Instantiate(fishIndex[2], transform.position = new Vector3(transform.position.x + -0.5f, transform.position.y, transform.position.z), transform.rotation);

        newhead.GetComponent<Rigidbody>().AddForce(Vector3.left * -Random.Range(2, 5), ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddForce(Vector3.right * -Random.Range(2, 5), ForceMode.Impulse);
        newhead.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(3, 6), ForceMode.Impulse);
        newhead.GetComponent<Rigidbody>().AddTorque(Vector3.forward * Random.Range(2, 3), ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(3, 6), ForceMode.Impulse);
        newtail.GetComponent<Rigidbody>().AddTorque(Vector3.forward * -Random.Range(2, 3), ForceMode.Impulse);
    }

    //create sashimi
    public void HalfFishCut()
    { 
        if (fishIndex[0] != null)
        {
            Fish newLast1 = Instantiate(fishIndex[1], transform.position, transform.rotation);
            newLast1.GetComponent<Rigidbody>().AddForce(Vector3.right * Random.Range(1, 5), ForceMode.Impulse);
            newLast1.GetComponent<Rigidbody>().AddForce(Vector3.up * -Random.Range(3, 6), ForceMode.Impulse);
            newLast1.GetComponent<Rigidbody>().AddTorque(Vector3.forward * Random.Range(2, 3), ForceMode.Impulse);
        }
        if (fishIndex[0] != null)
        {
            Fish newLast2 = Instantiate(fishIndex[1], transform.position, transform.rotation);
            newLast2.GetComponent<Rigidbody>().AddForce(Vector3.left * Random.Range(1, 5), ForceMode.Impulse);
            newLast2.GetComponent<Rigidbody>().AddForce(Vector3.up * -Random.Range(3, 6), ForceMode.Impulse);
            newLast2.GetComponent<Rigidbody>().AddTorque(Vector3.forward * -Random.Range(2, 3), ForceMode.Impulse);
        }
    }
    public void PufferHalf()
    {
        if (fishIndex[0] != null)
        {
            Fish newLast1 = Instantiate(fishIndex[1], transform.position, transform.rotation);
            newLast1.GetComponent<Rigidbody>().AddForce(Vector3.right * Random.Range(1, 5), ForceMode.Impulse);
            newLast1.GetComponent<Rigidbody>().AddForce(Vector3.up * -Random.Range(3, 6), ForceMode.Impulse);
            newLast1.GetComponent<Rigidbody>().AddTorque(Vector3.forward * Random.Range(2, 3), ForceMode.Impulse);
        }
        if (fishIndex[0] != null)
        {
            Fish newLast2 = Instantiate(fishIndex[1], transform.position, transform.rotation);
            newLast2.GetComponent<Rigidbody>().AddForce(Vector3.left * Random.Range(1, 5), ForceMode.Impulse);
            newLast2.GetComponent<Rigidbody>().AddForce(Vector3.up * -Random.Range(3, 6), ForceMode.Impulse);
            newLast2.GetComponent<Rigidbody>().AddTorque(Vector3.forward * -Random.Range(2, 3), ForceMode.Impulse);
        }
    }
    public void SquidHalf()
    {
        if (fishIndex[0] != null)
        {
            Fish newLast1 = Instantiate(fishIndex[1], transform.position, transform.rotation);
            newLast1.GetComponent<Rigidbody>().AddForce(Vector3.right * Random.Range(1, 5), ForceMode.Impulse);
            newLast1.GetComponent<Rigidbody>().AddForce(Vector3.up * -Random.Range(3, 6), ForceMode.Impulse);
            newLast1.GetComponent<Rigidbody>().AddTorque(Vector3.forward * -Random.Range(2, 3), ForceMode.Impulse);
        }
        if (fishIndex[0] != null)
        {
            Fish newLast2 = Instantiate(fishIndex[1], transform.position, transform.rotation);
            newLast2.GetComponent<Rigidbody>().AddForce(Vector3.left * Random.Range(1, 5), ForceMode.Impulse);
            newLast2.GetComponent<Rigidbody>().AddForce(Vector3.up * -Random.Range(3, 6), ForceMode.Impulse);
            newLast2.GetComponent<Rigidbody>().AddTorque(Vector3.forward * Random.Range(2, 3), ForceMode.Impulse);
        }
    }

    public void Puffercut()
    {
        // loop for a random number between -5 and 5
        // repeat if number is between -2 and 2
        float randomNumber;
        do {
            randomNumber = Random.Range(-4, 4);
        } while (randomNumber < 3 && randomNumber > -3);

        // instantiate halves in opposite directions
        Fish newPufferHalf = Instantiate(fishIndex[1], transform.position, transform.rotation);
        Fish newPufferPoison = Instantiate(fishIndex[2], transform.position, transform.rotation);
        if (randomNumber >= 0) // if puffer half is moving right, invert x scale
        {
            newPufferHalf.transform.localScale = new Vector3
                (newPufferHalf.transform.localScale.x * -1,
                newPufferHalf.transform.localScale.y, 
                newPufferHalf.transform.localScale.z);
        }
        else
        { // if puffer poison is moving right, invert x scale
            newPufferPoison.transform.localScale = new Vector3
                (newPufferPoison.transform.localScale.x * -1,
                newPufferPoison.transform.localScale.y,
                newPufferPoison.transform.localScale.z);
        }
        newPufferHalf.GetComponent<Rigidbody>().AddForce(Vector3.left * randomNumber, ForceMode.Impulse);
        newPufferHalf.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(4, 6), ForceMode.Impulse);

        newPufferPoison.GetComponent<Rigidbody>().AddForce(Vector3.right * randomNumber, ForceMode.Impulse);
        newPufferPoison.GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(4, 6), ForceMode.Impulse);
    }

    private void Poison()
    {
        if (onPlate)
        {
            poisoned = true;
            rend.material.color = fishcolor;
        }
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
