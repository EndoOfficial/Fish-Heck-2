using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Handle screen touches
// Mouse clicks emulate touches

public class TouchInput : MonoBehaviour
{
	private Vector2 startPosition;      // screen
	private Vector2 lastPosition;       // screen - last frame
	private Vector2 moveDirection;      // screen
	private Vector2 endPosition;        // screen

	private long touchStartTicks;
	private long touchEndTicks;
	private float TickSpeedFactor = 100000f;        // to reduce swipe time

	private float swipeThreshold = 20f;     // anything less not considered a valid swipe (ie. a tap or accidental swipe)

	public enum SwipeCardinal
	{
		None,
		Up,
		Down,
		Left,
		Right,
		Tap

	};
	private Vector3[] Directions90 = {
		Vector3.up,
		Vector3.down,
		Vector3.left,
		Vector3.right,
	};

	private void Update()
	{
		
		// track a single touch
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			// handle finger movements based on TouchPhase
			switch (touch.phase)
			{
				case TouchPhase.Began:
					StartTouch(touch.position, Input.touchCount);
					break;

				case TouchPhase.Moved:
					MoveTouch(touch.position, Input.touchCount);
					break;

				case TouchPhase.Ended:
					EndTouch(touch.position, Input.touchCount);
					break;

				case TouchPhase.Stationary:         // touching but hasn't moved
					break;

				case TouchPhase.Canceled:           // system cancelled touch
					break;
			}
		}

		// emulate touch with left mouse
		else if (Input.GetMouseButtonDown(0))
		{
			StartTouch(Input.mousePosition, 1);
		}
		else if (Input.GetMouseButton(0))
		{
			MoveTouch(Input.mousePosition, 1);
		}
		else if (Input.GetMouseButtonUp(0))
		{
			EndTouch(Input.mousePosition, 1);
		}

		// right mouse == 2 finger swipe
		else if (Input.GetMouseButtonDown(1))
		{
			StartTouch(Input.mousePosition, 2);
		}
		else if (Input.GetMouseButton(1))
		{
			MoveTouch(Input.mousePosition, 2);
		}
		else if (Input.GetMouseButtonUp(1))
		{
			EndTouch(Input.mousePosition, 2);
		}
	}

	private void GetSwipeCardinal()
	{
		var swipeDistance = (endPosition - startPosition).magnitude;
		Vector3 clampedDirection = ClampTo90(moveDirection);        // normalised
		SwipeCardinal cardinal = SwipeCardinal.None;

		if (swipeDistance < swipeThreshold)     // ie. a tap or accidental swipe
		{
			cardinal = SwipeCardinal.Tap;
		}
		else        // valid swipe
		{
			if (clampedDirection == Vector3.up)
				cardinal = SwipeCardinal.Up;
			else if (clampedDirection == Vector3.down)
				cardinal = SwipeCardinal.Down;
			else if (clampedDirection == Vector3.left)
				cardinal = SwipeCardinal.Left;
			else if (clampedDirection == Vector3.right)
				cardinal = SwipeCardinal.Right;
		}

		//Debug.Log($"GetCardinal {cardinal} swipeDistance {swipeDistance}");
		if (cardinal != SwipeCardinal.None)
			GameEvents.OnSwipeCardinal?.Invoke(cardinal);
	}
	private Vector3 ClampTo90(Vector3 direction)
	{
		Vector3 result = Directions90[0];
		float nearest = Vector3.Dot(direction, Directions90[0]);      // .Dot returns 1 to -1 to indicate closeness to vertical (0 is horizontal)

		for (int i = 1; i < Directions90.Length; i++)
		{
			var dotToCompare = Vector3.Dot(direction, Directions90[i]);

			if (dotToCompare > nearest)
			{
				nearest = dotToCompare;
				result = Directions90[i];
			}
		}

		return result;
	}
	private void StartTouch(Vector2 screenPosition, int touchCount)
	{
		startPosition = screenPosition;
		touchStartTicks = DateTime.Now.Ticks;

		lastPosition = startPosition;

		GameEvents.OnSwipeStart?.Invoke(startPosition, touchCount);
	}

	private void MoveTouch(Vector2 screenPosition, int touchCount)
	{

		Vector2 movePosition = screenPosition;

		if (movePosition != lastPosition)
		{
			moveDirection = (movePosition - lastPosition).normalized;

			float moveDistance = Mathf.Abs(Vector2.Distance(lastPosition, movePosition));
			float moveSpeed = moveDistance / Time.deltaTime;     // speed = distance / time

			GameEvents.OnSwipeMove?.Invoke(movePosition, moveDirection, moveSpeed, touchCount);

			lastPosition = movePosition;
		}
		else
			GameEvents.OnSwipeMove?.Invoke(movePosition, Vector2.zero, 0f, touchCount);
	}

	private void EndTouch(Vector2 screenPosition, int touchCount)
	{

		endPosition = screenPosition;
		touchEndTicks = DateTime.Now.Ticks;
		Vector2 moveDirection = (endPosition - startPosition).normalized;

		float moveDistance = Mathf.Abs(Vector2.Distance(startPosition, endPosition));
		float moveSpeed = 0;     // distance / time
		float touchTime = touchEndTicks - touchStartTicks;

		if (touchTime > 0)            // should be!!
		{
			float swipeTime = touchTime / TickSpeedFactor;
			moveSpeed = moveDistance / swipeTime;     // speed = distance / time
		}

		if (moveSpeed > 0)
		{
			GameEvents.OnSwipeEnd?.Invoke(endPosition, moveDirection, moveSpeed, touchCount);
		}

		GetSwipeCardinal();     // if a 'valid' swipe
	}
}