using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed/100f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jellyfish")
        {
            Destroy(other.gameObject);
            GameEvents.JellyDestroy?.Invoke();
        }
    }
}
