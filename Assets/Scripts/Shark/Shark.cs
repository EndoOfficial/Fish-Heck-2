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
    {
        scaleChange = new Vector3(0.2f, 0.2f, 0.2f);
    }
    private void Update()
    {
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
    {

        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.gameObject.tag == "Coin")
        {
            GameEvents.CoinEat.Invoke();
            Destroy(other.gameObject);
        }
      
    }
    private void sharkShrink()
    {
        shark.transform.localScale -= scaleChange * 0.6f;
    }
}
