using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public Transform target;     // The position that the camera will be following
	public float smoothing = 5f; // The speed with which the camera wil be following, the lower value more smoother

	Vector3 offset;              // The initial offset from the target


	void Start () 
	{
		offset = transform.position - target.position;
	}
	
	void LateUpdate () 
	{
		// Create a position the camera is aiming for based on the offset from the target
		Vector3 targetCamPos = target.position + offset;

		// Smoothly interpolate between the camera's current position and it's target position
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
		//Camera.main.transform.LookAt(target.position);
	}
}
