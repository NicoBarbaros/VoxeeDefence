using UnityEngine;
using System.Collections;

public class JoyStickController : MonoBehaviour {
	
	
	public JoyStickScript controllJoystick;
	public Transform cameraTransform;

//	//speed controller
	public float speed = 5.0f;
	public Vector2 rotationSpeed = new Vector2(50,25);
	
	
	private Transform thisTransform;
	private CharacterController character;
	private Vector3 velocity;
	private Vector3 movement;
	// Use this for initialization
	void Start () 
	{	
		//Cache component lookup at startup instead of doing this every frame
		thisTransform = GetComponent<Transform>();
		character = GetComponent<CharacterController>();
		GameObject spawn = GameObject.Find("PlayerSpawn");
		if(spawn)
			thisTransform.position = spawn.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () 
	{	
		//going through all cameras I got in the scene
		foreach(Camera c in Camera.allCameras)
		{
			//Checking which one is enabled
			if(c.camera.enabled){
				Debug.Log(c.transform);
				//Accordingly to the new camera direction we will move.
				movement = c.transform.TransformDirection(new Vector3(controllJoystick.position.x, 0, controllJoystick.position.y));
				
			}

		}
		//Vector3 movement = cameraTransform.TransformDirection(new Vector3(controllJoystick.position.x, 0, controllJoystick.position.y));
		
		//We only want the camera-space horizontal direction
		movement.y = 0;
		
		//Adjust magnitude after ingoring vertical movement
		movement.Normalize();
		
		//Use the largest component of the joystick position for the speed
		
		Vector2 absJoyPos = new Vector2(Mathf.Abs(controllJoystick.position.x), Mathf.Abs(controllJoystick.position.y));
		movement *= speed * ((absJoyPos.x > absJoyPos.y) ? absJoyPos.x : absJoyPos.y);
		
		movement += velocity;
		movement += Physics.gravity;
		movement *= Time.deltaTime;
		
		//Actually move the character
		character.Move(movement);
		
		FaceMovementDirection();


	}
	
	void FaceMovementDirection()
	{
		Vector3 horizontalVelocity = character.velocity;
		horizontalVelocity.y = 0; //Ignore vertical movement
		
		// If moving significantly in a new direction, point that character in that direction
		if(horizontalVelocity.magnitude > 0.1)
			thisTransform.forward = horizontalVelocity.normalized;
	}
	
	void OnEndGame()
	{
//		// Disable joystick when the game ends
		controllJoystick.Disable();
		
		// Don't allow any more control changes when the game ends
		this.enabled = false;
	}
}
