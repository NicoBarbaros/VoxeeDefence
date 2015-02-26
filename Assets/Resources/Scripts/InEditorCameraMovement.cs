using UnityEngine;
using System.Collections;

public class InEditorCameraMovement : MonoBehaviour {

	public float camSpeed = 1.0f;
	private int GUISize = 25;

	// Update is called once per frame
	void Update () {
		Rect recDown = new Rect(0, 0, Screen.width, GUISize);
		Rect recUp = new Rect(0, Screen.height - GUISize, Screen.width, GUISize);
		Rect recLeft = new Rect(0, 0, GUISize, Screen.height);
		Rect recRight = new Rect(Screen.width - GUISize, 0, GUISize, Screen.height);

#if UNITY_EDITOR
		if(recDown.Contains(Input.mousePosition))
			transform.Translate(camSpeed, 0, 0, Space.World);

		if(recUp.Contains(Input.mousePosition))
			transform.Translate(-camSpeed, 0, 0, Space.World);

		if(recLeft.Contains(Input.mousePosition))
			transform.Translate(0, 0, -camSpeed, Space.World);

		if(recRight.Contains(Input.mousePosition))
			transform.Translate(0, 0, camSpeed, Space.World);
#endif
	}
}
