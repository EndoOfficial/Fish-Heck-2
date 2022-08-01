using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySetter : MonoBehaviour
{
    public float gravity = 9.81f;
    // Start is called before the first frame update
    void Awake()
    {
        Physics.gravity = new Vector3(0, -gravity, 0);
    }
}
