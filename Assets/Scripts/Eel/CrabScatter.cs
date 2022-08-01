using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabScatter : CrabBehaviour
{
    private void OnDisable()
    {
        this.crab.chase.Enable();
    }
    private void OnTriggerEnter2D(Collider2D other) //this will fire even if the sript is disabled!!! so check whether or not itis in code
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled) //checks if this script is enabled and if frightened is enabled as frightened should override this 
        {
            int index = Random.Range(0, node.availableDirections.Count);

            if (node.availableDirections[index] == -this.crab.movement.direction && node.availableDirections.Count > 1)
            {
                index++;

                if (index >= node.availableDirections.Count)
                {
                    index = 0;
                }
            }

            this.crab.movement.SetDirection(node.availableDirections[index]);
        }
    }
}
