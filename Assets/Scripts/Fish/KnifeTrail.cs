using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeTrail : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnSwipeStart += OnSwipeStart;
        GameEvents.OnSwipeEnd += OnSwipeEnd;
    }
    private void OnDisable()
    {
        GameEvents.OnSwipeStart -= OnSwipeStart;
        GameEvents.OnSwipeEnd -= OnSwipeEnd;
    }

    private void OnSwipeStart(Vector2 startPosition, int touchCount)
    {
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        em.enabled = true;
    }
    private void OnSwipeEnd(Vector2 endPosition, Vector2 moveDirection, float moveSpeed, int touchCount)
    {
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        em.enabled = false;
    }
}
