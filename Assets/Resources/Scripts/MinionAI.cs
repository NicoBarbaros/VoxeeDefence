using UnityEngine;
using System.Collections;

public class MinionAI : MonoBehaviour {

	private Transform target;
	private float rotationSpeed = 5;
	private Transform myTransform;


	private Vector3 dir;
	void Awake()
	{
		myTransform = transform;
	}
	// Use this for initialization
	void Start () 
	{
		target = GameObject.FindWithTag("Target").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float moveSpeed = Random.Range(30.0f,40.0f);
		dir = (target.position - transform.position).normalized;
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, 1))
		{
			if(hit.transform != this.transform)
			{
				Debug.DrawLine(transform.position, transform.forward, Color.red);
				dir += hit.normal * 20;
			}
		}

		// more raycasts    
		Vector3 leftRay = transform.position + new Vector3(-0.125f, 0f, 0f);
		Vector3 rightRay = transform.position + new Vector3(0.125f, 0f, 0f);
		
		// check for leftRay raycast
		if (Physics.Raycast(leftRay, transform.forward, out hit, 1)) // 20 is raycast distance
		{
			if (hit.transform != this.transform)
			{
				Debug.DrawLine (leftRay, hit.point, Color.red);
				
				dir += hit.normal * 20; // 20 is force to repel by
			}
		}
		
		// check for rightRay raycast
		if (Physics.Raycast(rightRay, transform.forward, out hit, 1)) // 20 is raycast distance
		{
			if (hit.transform != this.transform)
			{
				Debug.DrawLine (rightRay, hit.point, Color.green);
				
				dir += hit.normal * 20; // 20 is force to repel by
			}
		}

//
//		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position),
//		                                    rotationSpeed * Time.deltaTime);

//		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(dir),
//		                                    rotationSpeed * Time.deltaTime);
//		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		Debug.DrawRay (transform.position, forward, Color.green);
		Debug.DrawLine(transform.position, target.position);

		// rotation
		var rot = Quaternion.LookRotation (dir);
		
		//print ("rot : " + rot);
		transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.deltaTime);
		
		//position
		transform.position += transform.forward * (2 * Time.deltaTime); // 20 is speed

	}
}
