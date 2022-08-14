using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ReefRaiderWinCondition : MonoBehaviour
{
    public Transform pellets;
    public Eel eel;

    private void OnEnable()
    {
        GameEvents.PelletCheck += PelletEaten;
    }
    private void OnDisable()
    {
        GameEvents.PelletCheck -= PelletEaten;
    }
    private bool HasRemainingPellets() //bool that flags whether or not there are still pellets on the field
    {
        //check for pellets via their transforms
        foreach (Transform pellets in pellets)
        {
            if(pellets.gameObject.activeSelf)
            {
                return true; // there are still pellets in the scene
            }
        }
        return false; //if there are no more pellets, return false
    }
    public void PelletEaten() //activates when a pellet is eaten thru events
    {
        Debug.Log("PelletEaten");

        if (!HasRemainingPellets()) //once there are no more pellets, invoke new round
        {
            ResetPellets();
        }
    }
    private void ResetPellets()
    {
        foreach (Transform pellets in pellets) //all the pellets in should turn back on
        {
            pellets.gameObject.SetActive(true); 
        }
    }
}
