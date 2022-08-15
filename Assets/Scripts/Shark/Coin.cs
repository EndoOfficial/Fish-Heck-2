using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coin : MonoBehaviour
{
    public float spinSpeed = 100f;
    private int setScore=1;

    void Update()
    {
        transform.Rotate(0f, 0f, Time.deltaTime * spinSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // send event for scoring
        if (other.gameObject.tag == "Player")
        {
            GameEvents.FishScore?.Invoke(setScore);
            GameEvents.TutorialOff?.Invoke();
            Destroy(this.gameObject);
        }
        
    }
    
}
