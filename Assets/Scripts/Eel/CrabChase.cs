using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabChase : CrabBehaviour
{
    private void OnDisable()
    {
        crab.scatter.Enable();
    }
    private void OnTriggerEnter2D(Collider2D other) //this will fire even if the sript is disabled!!! so check whether or not itis in code
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled ) //checks if this script is enabled and if frightened is enabled as frightened should override this 
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            foreach (Vector2 availiableDirection in node.availableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availiableDirection.x, availiableDirection.y, 0.0f);
                float distance = (this.crab.target.position - newPosition).sqrMagnitude;

                if (distance < minDistance)
                {
                    direction = availiableDirection;
                    minDistance = distance;
                }
            }
            this.crab.movement.SetDirection(direction);
        }
    }
}
