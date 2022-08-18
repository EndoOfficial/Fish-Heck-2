using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeze : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 force;
    private void OnEnable()
    {
        GameEvents.TutorialStart += TutorialStart;
        GameEvents.TutorialStop += TutorialStop;
    }
    private void OnDisable()
    { 
        GameEvents.TutorialStart -= TutorialStart;
        GameEvents.TutorialStop -= TutorialStop;
    }

    private void Start()
    {
        if (GetComponent<Rigidbody>() != null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    private void TutorialStart()
    {
        if (rb != null)
        {
            force = rb.velocity;
            rb.isKinematic = true;
        }
    }

    private void TutorialStop()
    {
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.velocity = force;
        }
    }
}
