using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Shark : MonoBehaviour
{
    private Vector3 scaleChange;
    public GameObject shark;

    private void Awake()
    { //the rate at which the the shark grows
        scaleChange = new Vector3(0.2f, 0.2f, 0.2f);
    }
    private void Update()
    { // shark growing over time
        shark.transform.localScale += scaleChange * Time.deltaTime;
    }
    private void OnEnable()
    {
        GameEvents.CoinScore += sharkShrink;
    }
    private void OnDisable()
    {
        GameEvents.CoinScore -= sharkShrink;
    }
    private void OnTriggerEnter(Collider other)
    { //Sharks eating various things

        if (other.gameObject.tag == "Player")
        { //Shark eating the player, will likely be changed to facilitate a lose screen 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.gameObject.tag == "Coin")
        { //The sharks hit the coin and they spawn somewhere else
            GameEvents.CoinEat.Invoke();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Spawner")
        {  //disable the spawner when shark touches them
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    { //reeanables the spawner after the shark has been sufficiantly pushed back
        if (other.gameObject.tag == "Spawner")
        {
            gameObject.SetActive(true);
        }
    }
    private void sharkShrink()
    { //shark shrinking after a coin has been aquired
        shark.transform.localScale -= scaleChange * 0.6f;
    }
}
