using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use events to access the touchinput and then use them to tigger vector 3 movement
public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public Rigidbody _rigidbody;
    private Vector3 vctr;
    public AudioSource source;
    public AudioClip chomp;
    private void OnEnable()
    {
        GameEvents.OnSwipeEnd += OnSwipeEnd;
    }

    private void OnDisable()
    {
        GameEvents.OnSwipeEnd -= OnSwipeEnd;
    }

    private void OnSwipeEnd(Vector2 MovePosition, Vector2 MoveDirection, float MoveSpeed, int TouchCount)
    {
        _rigidbody.velocity = Vector3.zero;
        vctr = MoveDirection;
        vctr.z = vctr.y;
        vctr.y = 0;
        _rigidbody.AddForce(vctr * speed);
    }
    private void Update()
    {
        _rigidbody.AddForce(Vector3.down);
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Coin")
        {
            source.PlayOneShot(chomp);
        }
    }
}