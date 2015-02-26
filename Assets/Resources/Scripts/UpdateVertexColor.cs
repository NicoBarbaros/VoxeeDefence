using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class UpdateVertexColor : MonoBehaviour {

	public Color newColor = Color.grey;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Mesh mesh = GetComponent<MeshFilter>().sharedMesh;

		Color[] colors = new Color[mesh.vertices.Length];
		int i = 0;

		// loop through verteces
		while(i < mesh.vertices.Length)
		{
			colors[i] = newColor;
			i++;
		}

		mesh.colors = colors;
	}
}
