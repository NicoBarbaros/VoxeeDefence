using UnityEngine;
using System.Collections;

public class StartCameraScript : MonoBehaviour {
	public Transform target;
	public float smoothTime = 0.3F;
	private float yVelocitx = 0.1F;
	private float yVelocity = 0.1F;
	private float yVelocitz = 0.1F;

	IEnumerator Start()
	{
		StartCoroutine("UpdatePosition", 2.0F);
		yield return new WaitForSeconds(2);
		StopCoroutine("UpdatePosition");
	}
	
	IEnumerator UpdatePosition(float someParameter) {
		bool exists = true;
		while (true) {
			float newPositionx = Mathf.SmoothDamp(transform.position.x, target.position.x, ref yVelocitx, smoothTime);
			float newPositiony = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
			float newPositionz = Mathf.SmoothDamp(transform.position.z, target.position.z, ref yVelocitz, smoothTime);
			transform.position = new Vector3(newPositionx, newPositiony ,newPositionz);
			yield return null;
		}
	}
}