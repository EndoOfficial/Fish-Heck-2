using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed/1f *Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jellyfish")
        {
            GameEvents.JellyMove?.Invoke(other);
        }

        else if (other.tag == "Jellyfish2")
        {
            GameEvents.SmallJellyMove?.Invoke(other);
        }
    }
    private void OnEnable()
    {
        GameEvents.Difficulty += Difficulty;
    }
    private void OnDisable()
    {
        
        GameEvents.Difficulty -= Difficulty;
    }

    private void Difficulty()
    {
        moveSpeed += 0.01f;
    }
}
