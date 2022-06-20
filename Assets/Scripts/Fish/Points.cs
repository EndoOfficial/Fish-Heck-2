using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        GameEvents.DoPoints += DoPoints;
    }

    // Update is called once per frame
    private void OnDisable()
    { 
        GameEvents.DoPoints -= DoPoints;
    }

    private void DoPoints(int isScore)
    {
        Debug.Log($"show points {isScore}");
    }
}
