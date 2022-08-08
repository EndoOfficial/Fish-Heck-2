using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour
{
    public float moveSpeed;
    private bool gameOver = false;

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed / 1f * Time.deltaTime);
        }
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
        GameEvents.GameOver += GameOver;
    }
    private void OnDisable()
    {
        
        GameEvents.Difficulty -= Difficulty;
        GameEvents.GameOver -= GameOver;
    }

    private void Difficulty()
    {
        if (moveSpeed <= 6.2f)
        {
            moveSpeed += 0.01f;
        }
    }
    private void GameOver()
    {
        gameOver = true;
    }
}
