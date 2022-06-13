using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coin : MonoBehaviour
{
    public float spinSpeed = 100f;
    public EventTrigger.TriggerEvent scoreTrigger;

    void Update()
    {
        this.transform.Rotate(0f, 0f, Time.deltaTime * this.spinSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            GameEvents.CoinScore.Invoke();
            Destroy(this.gameObject);
        }
    }
    
}
