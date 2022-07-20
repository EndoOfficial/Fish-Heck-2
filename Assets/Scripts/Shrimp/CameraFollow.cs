using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Shrimp;
    public Transform Whale;
    private int setScore = 1;
    private int count = 0;

    private void LateUpdate()
    {
        if (Shrimp != null)
        {
            if (Shrimp.position.y > transform.position.y)
            {
                Vector3 newPosition = new Vector3(transform.position.x, Shrimp.position.y, transform.position.z);
                Vector3 oldPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                transform.position = newPosition;
                count++;
                if (count >= 10)
                {
                    count = 0;
                    GameEvents.FishScore?.Invoke(setScore);
                }
            }
        }
        
        if (Whale.position.y < transform.position.y - 35f)
        {
            Whale.position = new Vector2(Whale.position.x, transform.position.y - 35f);
        }
    }
}
