using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Platform : MonoBehaviour
{ 
    public Transform [] TiltLibrary;
    public GameObject platform;
    private void OnEnable()
    {
        GameEvents.TiltTrigger += Tilt;
    }
    private void OnDisable()
    {
        GameEvents.TiltTrigger -= Tilt;
    }
    private void Tilt()
    { //tilts the platform after the threshold count has reached a certain point 
        // Achieves this by picking from an array of rotations 
        int randomInt = Random.Range(0, TiltLibrary.Length);
        Quaternion randomRotation = TiltLibrary[randomInt].rotation;

        platform.transform.rotation = randomRotation;

    }
}
