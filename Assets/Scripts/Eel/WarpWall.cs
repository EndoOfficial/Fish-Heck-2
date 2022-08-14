using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpWall : MonoBehaviour
{
    public Transform connection; //other warp

    private void OnTriggerEnter2D(Collider2D other) //moves player to the other box collider when touched
    {
        Vector3 position = connection.position;
        position.z = other.transform.position.z;
        other.transform.position = position;
    } 
}
