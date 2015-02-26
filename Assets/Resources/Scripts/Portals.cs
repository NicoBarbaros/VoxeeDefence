using UnityEngine;
using System.Collections;

public class Portals : MonoBehaviour {

	// Use this for initialization
	public Transform destination;
	public GameObject cam1;
	public GameObject cam2;

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	IEnumerator  OnTriggerEnter(Collider other)
	{
		yield return new WaitForSeconds(1);
		cam1.camera.enabled = false;
		cam1.GetComponent<AudioListener>().enabled = false ;
		cam2.camera.enabled = true;
		cam2.GetComponent<AudioListener>().enabled = true;
		cam2.audio.Play();
		Vector3 pos = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);
		other.gameObject.transform.position = pos;
	}
}
