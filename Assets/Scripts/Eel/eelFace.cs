using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eelFace : MonoBehaviour
{
    public Movement parent;
    public Transform eel;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            parent.touch = true;
            eel.position = new Vector2(Mathf.Round(eel.position.x)-.5f, Mathf.Round(eel.position.y)-.5f);
        }
        else
        {
            parent.touch = false;
        }
    }
}
