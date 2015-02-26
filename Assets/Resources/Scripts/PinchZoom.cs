using UnityEngine;

public class PinchZoom : MonoBehaviour
{
	public float zoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
	public float speed = 20f;

	private float oldAngle = 0.0f;
	public float rotationSpeed = 10f;
	private float deltaAngle = 0.0f;
	RaycastHit hitInfo;

	public float smoothTime = 0.3F;
	private float yVelocity = 0.0F;
	TapToMove obj = new TapToMove();
	void Start()
	{
		hitInfo = new RaycastHit();
	}
	void Update()
	{
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

	// If there are two touches on the device...
		if (Input.touchCount == 2)
		{
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);


			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;



		
			Vector2 newVector = touchZero.position - touchOne.position;
			Vector2 nextVector = newVector;
			float newAngle = Mathf.Atan2 (newVector.y, newVector.x) * Mathf.Rad2Deg;

			deltaAngle = Mathf.DeltaAngle(newAngle, oldAngle);
			oldAngle = newAngle;

			//	Debug.Log(newVector);
			//transform.Rotate(Vector3.forward * Time.deltaTime * deltaAngle * rotationSpeed);
			//if(newVector.x.Equals(nextVector.x))
			//transform.Rotate(0, 0, newAngle);

				// Find the magnitude of the vector (the distance) between the touches in each frame.
				float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
				float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
				
				// Find the difference in the distances between each frame.
				float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
				//transform.Translate(0,0,-deltaMagnitudeDiff, Space.Self);
			  transform.Translate (Vector3.forward * -deltaMagnitudeDiff * speed * Time.deltaTime);
			//float move = speed *Time.deltaTime;
		//	transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,0, -deltaMagnitudeDiff), move);
		}
//
		else if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			Touch touchZero = Input.GetTouch(0);
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchdeltaMag = (touchZero.position - touchZeroPrevPos);
			float newPositiony = Mathf.SmoothDamp(transform.position.y, transform.position.y + touchdeltaMag.y, ref yVelocity, smoothTime);
			float newPositionx = Mathf.SmoothDamp(transform.position.x, transform.position.x  +-touchdeltaMag.x, ref yVelocity, smoothTime);

			transform.Translate(new Vector3(touchdeltaMag.y * speed *Time.deltaTime, 0, -touchdeltaMag.x *speed *Time.deltaTime),Space.World);
			obj.touchCount = 0;


			Vector3 temp = new Vector3 (Mathf.Clamp(transform.position.x, -93, 120), transform.position.y, Mathf.Clamp(transform.position.z, -77, 160));
			transform.position = temp;

		}
	}

	void OrbitAround()
	{

	}
}