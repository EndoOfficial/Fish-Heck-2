using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eel : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;
    public Joystick joystick;

    private void Start()
    {
        ResetState();
    }
 /*   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
    }*/
    private void FixedUpdate() //movement is done through physics so using fixed update is key to a consistant experience
    {                          //Mathf.Round rounds the number to whole numbers, allowing for the griddy movement to work properly
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
       /* this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f);*/
    }

    private void OnEnable()
    {
        GameEvents.EelReset += ResetState;
    }
    private void OnDisable()
    {
        GameEvents.EelReset -= ResetState;
    }
    public Movement movement { get; private set; }
    private void Awake()
    {
        this.movement = GetComponent<Movement>();
    }
    private void Update()
    {
        //touch joystick code, seems to require horizontal, vertical inputs rather than vector2 so either adapt the movement script or look for different touch input

        /*float horizontalMove = joystick.Horizontal;
        bool jsRight = false;
        bool jsLeft = false;
        bool jsUp = false;
        bool jsDown = false;*/


       /* if (horizontalMove >= 0.2f)
        {
            jsRight = true;
            jsLeft = false;
        }
        else if (horizontalMove <= 0.2f)
        {
            jsRight = false;
            jsLeft = true;
        }
        else
        {
            jsRight = false;
            jsLeft = false;
        }

        float verticalMove = joystick.Vertical;

        if (verticalMove >= 0.2f)
        {
            jsUp = true;
            jsDown = false;
        }
        else if (verticalMove <= 0.2f)
        {
            jsUp = false;
            jsDown = true;
        }
        else
        {
            jsUp = false;
            jsDown = false;
        }*/
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
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);

        //jesus christ zach, what have you done

    }

    private void ResetState() //resets the player
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
        this.gameObject.SetActive(true);
    }
    private void Grow()
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
