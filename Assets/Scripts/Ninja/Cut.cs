using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    public GameObject trail;
    public GameObject cut;
    public GameObject cut2;
    private Vector3 point;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void OnEnable()
    {
        GameEvents.OnSwipeStart += OnSwipeStart;
        GameEvents.OnSwipeMove += OnSwipeMove;
        GameEvents.OnSwipeEnd += OnSwipeEnd;
        GameEvents.Cut += cutParticle;
    }
    private void OnDisable()
    {
        GameEvents.OnSwipeStart -= OnSwipeStart;
        GameEvents.OnSwipeMove -= OnSwipeMove;
        GameEvents.OnSwipeEnd -= OnSwipeEnd;
        GameEvents.Cut -= cutParticle;
    }

    private void OnSwipeStart(Vector2 startPosition, int touchCount)
    {
        trail.SetActive(true);
    }

    private void OnSwipeEnd(Vector2 endPosition, Vector2 moveDirection, float moveSpeed, int touchCount)
    {
        trail.SetActive(false);
    }

    private void OnSwipeMove(Vector2 movePosition, Vector2 moveDirection, float moveSpeed, int touchCount)
    {
        point = cam.ScreenToWorldPoint(movePosition);
        transform.position = new Vector3(point.x, point.y, point.z-1f);
    }

    private void cutParticle()
    {
        GameObject cut1 = Instantiate(cut, new Vector3(point.x, point.y, point.z+1f), Quaternion.identity);
        Destroy(cut1, 3f);
    }

}
