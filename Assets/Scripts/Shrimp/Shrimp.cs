using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrimp : MonoBehaviour
{
    public float jumpforce;
    private Rigidbody rb;
    public Camera cam;
    private Vector2 point;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void OnEnable()
    {
        GameEvents.OnSwipeMove += OnSwipeMove;
    }

    private void OnDisable()
    {
        GameEvents.OnSwipeMove -= OnSwipeMove;
    }

    private void OnSwipeMove(Vector2 movePosition, Vector2 moveDirection, float moveSpeed, int touchCount)
    {
        point = cam.ScreenToWorldPoint(movePosition);
        transform.position = new Vector2(point.x, transform.position.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jellyfish")
        {
            if (rb.velocity.y < 0f)
            {
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(Vector2.up * jumpforce, ForceMode.Impulse);
            }
        }
        if (other.tag == "Whale")
        {
            Destroy(this.gameObject);
            GameEvents.GameOver?.Invoke();
        }
    }
}
