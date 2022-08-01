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
    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.scatter = GetComponent<CrabScatter>();
        this.chase = GetComponent<CrabChase>();
    }
    private void Start()
    {
        ResetState();
    }
    public void ResetState() //has the crab start off roaming for difficulties sake
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();

        this.chase.Disable();
        this.scatter.Enable();

        if (this.initialBehavior != null)
        {
            this.initialBehavior.Enable();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //ghost collision with pacman
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameEvents.FishScore?.Invoke(setScore);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Tail"))
        {
            //damage tail or take life 
        }
    }
}
