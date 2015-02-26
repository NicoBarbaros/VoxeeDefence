using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float speed = 6f;     //How fast player is

	Vector3 movement;            // To store the movement we want to apply to the player
	Rigidbody playerRigidbody;   // Reference to the player's rigidbody
	int floorMask;               // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
	float camRayLength = 100f;   // The length of the ray from the camera into the scene.

	void Awake () 
	{
		// Create a layer mask for the floor layer.
		floorMask = LayerMask.GetMask("Floor");

		// Set up references.
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	// FixedUpdate works with fizics
	void FixedUpdate () 
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		Move (-h, -v);
		//Debug.Log("Turn");
		Turning();
	}

	void Move(float h, float v)
	{
		// Set the movement vector based on the axis input.
		movement.Set(h, 0f, v);

		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * Time.deltaTime;

		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition(transform.position + movement);
	}

	void Turning()
	{
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;
		Debug.Log("Turn");
		// Perform the raycast and if it hits something on the floor layer...
		if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
		{
			Debug.Log("Hit floor");
			Vector3 playerToMouse = floorHit.point - transform.position;

			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			playerToMouse.y = 0f;

			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

			// Set the player's rotation to this new rotation.
			playerRigidbody.MoveRotation (newRotation);
		}
	}
}
