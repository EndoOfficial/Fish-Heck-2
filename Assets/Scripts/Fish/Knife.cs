using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Camera cam;
    public LayerMask fish;
    public int scoreType;

    //Events
    private void OnEnable()
    {
        GameEvents.OnSwipeMove += OnSwipeMove;
    }

    private void OnDisable()
    {
        GameEvents.OnSwipeMove -= OnSwipeMove;
    }

    //when event is called do raycast on move position
    private void OnSwipeMove(Vector2 MovePosition, Vector2 MoveDirestion, float MoveSpeed, int TouchCount)
    {
        DoRaycast(MovePosition, fish);
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
                if (hitinfo.transform.gameObject.CompareTag("BigFish"))
                {
                    //when fish hit, cut fish
                    hitfish.FishCut();
                    Destroy(hitinfo.transform.gameObject);
                    scoreType = 1;
                    GameEvents.FishScore?.Invoke();
                }
                else if (hitinfo.transform.gameObject.CompareTag("FishHalf") && hitfish.canCut)
                {
                    //when fish hit, cut fish
                    hitfish.HalfFishCut();
                    Destroy(hitinfo.transform.gameObject);
                    GameEvents.FishScore?.Invoke();
                    scoreType = 1;
                    GameEvents.Getpoint?.Invoke(scoreType);
                }
            }
        }
        else
        {

        }
    }
}
