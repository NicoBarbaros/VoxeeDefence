using UnityEngine;
using System.Collections;

public class FlyingStoneRotate : MonoBehaviour {

	// Use this for initialization
	public float speed = 1.0f;
	void Start () 
	{
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}
}

