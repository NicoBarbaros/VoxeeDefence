using UnityEngine;
using System.Collections;

public class PureEnergy : MonoBehaviour {

	public float offset = 1.0f;
	public float smooth = 5.0f;
	public float rotateSpeed = 2.0f;
	private Vector3 startPositon;
	private Vector3 endPosition;

	private bool isTrigger = false;


	IEnumerator Start()
	{
		startPositon = transform.position;
		endPosition = transform.position + Vector3.up * offset;

		while(true)
		{
			yield return StartCoroutine(MoveObject(transform, startPositon, endPosition, smooth));
			yield return StartCoroutine(MoveObject(transform, endPosition, startPositon, smooth));
		}
	}
	
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while(i < 1.0f)
		{
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			transform.Rotate(Vector3.up, rotateSpeed* Time.deltaTime);
			yield return null;
		}
	}



	//IMPLEMENT THISs
	void OnTriggerEnter(Collider other)
	{
		
		if(other.gameObject.tag == "Player")
		{
			isTrigger = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			isTrigger = false;
		}
	}
	
	IEnumerator decreaseSpeed ()
	{
		while(true)
		{
	
			rotateSpeed += 2.0f;
		}
		rotateSpeed -= 2.0f;
		yield return new WaitForSeconds(5.0f); 
	}
}
