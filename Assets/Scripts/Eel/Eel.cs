using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eel : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;

    private void Start()
    {
        ResetState(); //places the player with the starting amount of segments at the starting transform
    }
 
    private void FixedUpdate() //movement is done through physics so using fixed update is key to a consistant experience
    {                          //Mathf.Round rounds the number to whole numbers, allowing for the griddy movement to work properly
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
    }

    private void OnEnable()
    {
        GameEvents.EelReset += ResetState;
        GameEvents.OnSwipeCardinal += OnSwipeCardinal;
    }
    private void OnDisable()
    {
        GameEvents.EelReset -= ResetState;
        GameEvents.OnSwipeCardinal -= OnSwipeCardinal;
    }

    private void OnSwipeCardinal(TouchInput.SwipeCardinal cardinal)
    {
        //uses the movement scripts variables, moves in directions
        if (cardinal == TouchInput.SwipeCardinal.Up)
        {
            this.movement.SetDirection(Vector2.up);
        }
        else if (cardinal == TouchInput.SwipeCardinal.Down)
        {
            this.movement.SetDirection(Vector2.down);
        }
        else if (cardinal == TouchInput.SwipeCardinal.Right)
        {
            this.movement.SetDirection(Vector2.right);
        }
        else if (cardinal == TouchInput.SwipeCardinal.Left)
        {
            this.movement.SetDirection(Vector2.left);
        }
        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward); //rotates the character around when moved
    }
    public Movement movement { get; private set; }
    private void Awake()
    {
        this.movement = GetComponent<Movement>();
    }
    private void Update()
    {
        //uses the movement scripts variables, moves in directions

        if (Input.GetKeyDown(KeyCode.W))
        {
            this.movement.SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.movement.SetDirection(Vector2.down);
        }
        else if ( Input.GetKeyDown(KeyCode.D))
        {
            this.movement.SetDirection(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.movement.SetDirection(Vector2.left);
        }
        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward); //rotates the character around when moved


    }

    private void ResetState() //resets the players segments and transform
    {
        for (int i =1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(this.transform);

        for(int i = 1; i < this.initialSize; i++)
        {
            segments.Add(Instantiate(this.segmentPrefab));
        }
        this.transform.position = Vector3.zero;
        this.movement.ResetState();
    }
    private void Grow() //adds another segment and moves it along the eel
    {
        Transform  segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Food")
        {
            Grow();
        }
     
    }
    private void OnCollisionEnter2D(Collision2D other) //destroys the crab when eaten
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Crab"))
        {
            Destroy(other.gameObject);
        }
    }
}
