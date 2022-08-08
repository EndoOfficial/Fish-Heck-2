using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    private float backgroundPos = 19.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("here");
        if (collision.CompareTag("Background"))
        {
            backgroundPos += 19.5f;
            collision.transform.position = new Vector2(collision.transform.position.x, backgroundPos);
        }
    }
}
