using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Camera cam;
    public LayerMask fish;
    public GameObject trail;
    public ParticleSystem knife;
    //Events
    private void OnEnable()
    {
        GameEvents.OnSwipeMove += OnSwipeMove;
        GameEvents.OnSwipeStart += OnSwipeStart;
        GameEvents.OnSwipeEnd += OnSwipeEnd;
    }

    private void OnDisable()
    {
        GameEvents.OnSwipeMove -= OnSwipeMove;
        GameEvents.OnSwipeStart -= OnSwipeStart;
        GameEvents.OnSwipeEnd -= OnSwipeEnd;
    }

    private void Start()
    {
    }

    //Start and stop trail on swipe start and end
    private void OnSwipeStart(Vector2 SP, int TC)
    {
        trail.SetActive(true);
    }
    private void OnSwipeEnd(Vector2 a, Vector2 b, float c, int d)
    {

        trail.SetActive(false);
    }
    //when event is called do raycast on move position
    private void OnSwipeMove(Vector2 MovePosition, Vector2 MoveDirestion, float MoveSpeed, int TouchCount)
    {
        DoRaycast(MovePosition, fish);
        trail.transform.position = Camera.main.ScreenToWorldPoint(MovePosition);
    }

    //raycast script

    private void DoRaycast(Vector2 MovePosition, LayerMask layer)
    {

        //raycast to mouse point OnSwipeMove
        Ray ray = cam.ScreenPointToRay(MovePosition);

        RaycastHit hitinfo;
        if (Physics.Raycast(ray, out hitinfo, 10f, fish))
        {
            var hitfish = hitinfo.transform.gameObject.GetComponent<Fish>();
            if(hitfish != null)
            {
                if (hitinfo.transform.gameObject.CompareTag("BigFish") && hitfish.canCut)
                {
                    //when fish hit, cut fish
                    hitfish.FishCut();
                    Destroy(hitfish.gameObject);
                }
                else if (hitinfo.transform.gameObject.CompareTag("FishHalf") && hitfish.canCut)
                {
                    //when fish hit, cut fish
                    hitfish.HalfFishCut();
                    Destroy(hitfish.gameObject);
                }
                else if (hitinfo.transform.gameObject.CompareTag("Pufferfish") && hitfish.canCut)
                {
                    hitfish.Puffercut();
                    Destroy(hitfish.gameObject);
                }
                else if (hitinfo.transform.gameObject.CompareTag("PufferPoison") && hitfish.canCut)
                {
                    GameEvents.LoseLife?.Invoke();
                    Destroy(hitfish.gameObject);
                    GameEvents.Poison?.Invoke();
                }
            }
        }
        else
        {

        }
    }
}
