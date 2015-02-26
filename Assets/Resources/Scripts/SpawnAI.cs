using UnityEngine;
using System.Collections;

public class SpawnAI : MonoBehaviour {

	public Transform spawnlocation;
	public GameObject minionPrefab;
	private bool  spawning = true;
	private int counter  = 0;
	void Start () {
		StartCoroutine(spawnMinion());
	
	}
	
	IEnumerator spawnMinion(){
		while(spawning)
		{

			yield return new WaitForSeconds(2.0f);
			Instantiate(minionPrefab,spawnlocation.transform.position, spawnlocation.transform.rotation);
			counter ++;
			if(counter == 20)
				spawning = false;
		}
	}
}
