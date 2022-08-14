using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float speedMultiplier = 1.0f;
    public Vector2 initialDirection;
    public LayerMask obstacleLayer;
   public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    public Vector2 nextDirection { get; private set; }
    public Vector3 startingPosition { get; private set; }

    public bool touch = false;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }
    private void Start()
    {
        ResetState();
        /*StartCoroutine(Moves());*/
    }
    public void ResetState()
    {
        this.speedMultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startingPosition;
        this.rigidbody.isKinematic = false;
        this.enabled = true;
    }
    private void Update()
    {
        if (this.nextDirection  != Vector2.zero)
        {
            SetDirection(this.nextDirection);
        }

    }
    private void FixedUpdate()
    {
        Vector2 position = this.transform.position;
        Vector2 translation = this.direction * this.speed * this.speedMultiplier * Time.fixedDeltaTime;
        if (!touch)
        {
        this.rigidbody.MovePosition(position + translation);
        }
        else
        {

        }
    }

 
    public void SetDirection(Vector2 direction, bool forced = false)
    { //allows for the buffering of inputs otherwise inputs would need to be stupid precise
        if(forced || !Occupied(direction))
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;
        }
        else
        {
            this.nextDirection = direction;
        }
    }
    public bool Occupied(Vector2 direction)
    { //using box casts to prevent clipping with the wall
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0f, direction, 1.5f, this.obstacleLayer);
        return hit.collider != null;
    }
}
