using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Camera cam;
    public LayerMask fish;
    private static bool tutorial = false;

    private void OnEnable()
    {
        GameEvents.OnSwipeMove += OnSwipeMove;
    }

    private void OnDisable()
    {
        GameEvents.OnSwipeMove -= OnSwipeMove;
    }

    private void OnSwipeMove(Vector2 movePosition, Vector2 moveDirection, float moveSpeed, int touchCount)
    {
        DoRaycast(movePosition, fish);
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
            if(hitfish != null && hitfish.canCut)
            {
                if (hitfish.transform.CompareTag("BigFish"))
                {
                    //when fish hit, cut fish
                    hitfish.FishCut();
                    if (!tutorial)
                    {
                        StartCoroutine(wait());
                    }
                }
                else if (hitfish.transform.CompareTag("BigFish2"))
                {
                    //when fish hit, cut fish
                    hitfish.FishCut2();
                    if (!tutorial)
                    {
                        StartCoroutine(wait());
                    }
                }
                else if (hitfish.transform.CompareTag("Squid"))
                {
                    //when fish hit, cut fish
                    hitfish.SquidCut();
                    if (!tutorial)
                    {
                        StartCoroutine(wait());
                    }
                }
                else if (hitfish.transform.CompareTag("SquidHalf"))
                {
                    //when fish hit, cut fish
                    hitfish.SquidHalf();
                    if (!tutorial)
                    {
                        GameEvents.TutorialStop?.Invoke();
                        Time.timeScale = 1f;
                        tutorial = true;
                    }
                    GameEvents.TutorialOff?.Invoke();
                }
                else if (hitinfo.transform.gameObject.CompareTag("FishHalf"))
                {
                    //when fish hit, cut fish
                    hitfish.HalfFishCut();
                    if (!tutorial)
                    {
                        GameEvents.TutorialStop?.Invoke();
                        Time.timeScale = 1f;
                        tutorial = true;
                    }
                    GameEvents.TutorialOff?.Invoke();
                }
                else if (hitinfo.transform.gameObject.CompareTag("Pufferfish"))
                {
                    hitfish.Puffercut();
                    if (!tutorial)
                    {
                        StartCoroutine(wait());
                    }
                }
                else if (hitinfo.transform.gameObject.CompareTag("PufferHalf"))
                {
                    hitfish.PufferHalf(); 
                    if (!tutorial)
                    {
                        GameEvents.TutorialStop?.Invoke();
                        Time.timeScale = 1f;
                        tutorial = true;
                    }
                    GameEvents.TutorialOff?.Invoke();

                }
                else if (hitinfo.transform.gameObject.CompareTag("PufferPoison"))
                {
                    GameEvents.LoseLife?.Invoke();
                    GameEvents.Poison?.Invoke();
                    //TODO Particle for poison cut
                }
                Destroy(hitfish.gameObject);
                GameEvents.CutSound?.Invoke();
                GameEvents.Cut?.Invoke();
                
            }
        }
        else
        {

        }

        IEnumerator wait()
        {
            yield return new WaitForSecondsRealtime(0.1f);
            GameEvents.TutorialStart?.Invoke();
        }
    }
}
