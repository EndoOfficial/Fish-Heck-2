using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Platform : MonoBehaviour
{ 
    public Transform [] TiltLibrary;
    public GameObject platform;
    public float tiltTime = 0.5f;
    public float maxTilt = 15;
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
        float randomX = Random.Range(0, maxTilt);
        float randomZ = Random.Range(0, maxTilt);
        LeanTween.rotate(gameObject, new Vector3 (randomX, 0,randomZ), tiltTime);

       // platform.transform.rotation = randomRotation;

    }
}
