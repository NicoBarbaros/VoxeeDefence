using UnityEngine;
using System.Collections;

public class RotateVortex : MonoBehaviour {

	public float amount = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * Time.deltaTime * amount);
	
	}
}
