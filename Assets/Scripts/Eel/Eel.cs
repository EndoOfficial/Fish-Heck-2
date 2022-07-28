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


    public Movement movement { get; private set; }
    private void Awake()
    {
        this.movement = GetComponent<Movement>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.movement.SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.movement.SetDirection(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.movement.SetDirection(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.movement.SetDirection(Vector2.left);
        }
        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);

       
    }

    private void ResetState()
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
        else if (other.tag == "Obstacle")
        {
            ResetState();
        }
    }
}
