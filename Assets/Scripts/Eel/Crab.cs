using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    public Rigidbody2D rigidbody { get; private set; }
    public Movement movement { get; private set; }
    public CrabScatter scatter { get; private set; }
    public CrabChase chase { get; private set; }
    public CrabBehaviour initialBehavior;
    public Transform target;
    public int setScore = 50;
    private bool canAttack; //bool to have the crab stop merkin the player so hard
    private float IFrames = 3f;

    private void Start()
    {
        canAttack = true;
    }
    private void OnCollisionEnter2D(Collision2D collision) //ghost collision with pacman
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameEvents.FishScore?.Invoke(setScore);
        }
     
    }
    private void OnTriggerEnter2D(Collider2D collision) //tail must be trigger to not effect the head
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Tail") && (canAttack = true)) 
        {
            GameEvents.LoseLife?.Invoke(); //lose ui int
            GameEvents.EelReset?.Invoke(); //reset the eels growth
            //cooldown to stop overeating
            StartCoroutine(DamageCooldown());
        }
    }
    private IEnumerator DamageCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(IFrames);
        canAttack = true;
    }
}
