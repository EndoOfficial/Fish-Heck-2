using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    public GameObject SoundPrefab;
    private void OnEnable()
    {
        GameEvents.CutSound += CutSound;
    }
    private void OnDisable()
    {
        GameEvents.CutSound -= CutSound;
    }

    private void CutSound()
    {
        if(SoundPrefab != null)
        {
            GameObject newSound = Instantiate(SoundPrefab, transform);
            Destroy(newSound.gameObject, 10f);
        }
    }
}
