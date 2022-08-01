using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinn : MonoBehaviour
{
    private float x;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-5, 5);
        x = Mathf.RoundToInt(x);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, x, 0));
    }
}
