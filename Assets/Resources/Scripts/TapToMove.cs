using UnityEngine;
using System.Collections;

public class TapToMove : MonoBehaviour {
	//flag to check if the user has tapped / clicked. 
	//Set to true on click. Reset to false on reaching destination
	private bool flag = false;

	//is selected or not the player
	private bool playerSelection = false;
	//destination point
	private Vector3 endPoint;
	private Vector3 targetPosition;

	//alter this to change the speed of the movement of player / gameobject
	public float duration = 50.0f;
	//vertical position of the gameobject
	private float yAxis;
	public SpriteRenderer selected;
	private int selectionCount;
	public int touchCount;
	private float angle;


	void Start(){
		//save the y axis value of gameobject
		yAxis = gameObject.transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {

		//check if the screen is touched / clicked   
		if((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(0).phase == TouchPhase.Stationary) || (Input.GetMouseButtonDown(0)))
		{
			//declare a variable of RaycastHit struct
			RaycastHit hit;
			//Create a Ray on the tapped / clicked position
			Ray ray;
			//for unity editor
			#if UNITY_EDITOR
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//for touch device
			#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			#endif

			//Check if the ray hits any collider
			if(Physics.Raycast(ray,out hit, 1000))
			{
			if(hit.transform.tag == "Floor" && selected.renderer.enabled){
					Debug.Log(touchCount);
					Debug.Log("Hit Floor");
					touchCount ++;
					if(touchCount >= 2){
					
						//set a flag to indicate to move the gameobject
						flag = true;
						//save the click / tap position
						endPoint = hit.point;
						//as we do not want to change the y axis value based on touch position, reset it to original y axis value
						endPoint.y = yAxis;
						targetPosition =hit.point;
					Vector3 move = Vector3.zero;
					move.x = hit.point.x;
					move.z = hit.point.z;
					Debug.Log("Hit point" + hit.point);
					//Debug.Log("Before new Move");
				//	Debug.Log("After new Move");
					Vector3 dir  = -move;
					angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
						Debug.Log(endPoint);
						touchCount = 0;
					}
					else{
						flag = false;
						endPoint = transform.position;
					}
				}
				if(hit.transform.tag == "Player")
								{
									selectionCount += 1;
									//Instantiate(selected, new Vector3(transform.position.x, 0, transform.position.y), Quaternion.identity);
									Debug.Log ("Hit player");
									if(selectionCount %2 == 0)
										selected.renderer.enabled = false;
									else selected.renderer.enabled = true;
								}

			}
//			

		}
		//check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
		if(flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)){ //&& !(V3Equal(transform.position, endPoint))){
			//move the gameobject to the desired position
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1/(duration*(Vector3.Distance(gameObject.transform.position, endPoint))));
			//Debug.Log(angle);
			//Quaternion newRotation = Quaternion.LookRotation(targetPosition - transform.position);
			//Debug.Log("NewRotation" + newRotation);
		//	gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation ,newRotation, Time.deltaTime * 8);
		}
		//set the movement indicator flag to false if the endPoint and current gameobject position are equal
		else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)) {
			flag = false;
			Debug.Log("I am here");
		}
		
	}
}