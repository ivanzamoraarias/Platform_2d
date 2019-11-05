using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

	public Color color1 = Color.red;
	public Color color2 = Color.blue;
	public float duration = 5.0F;

	Camera cameraObject;

	// Use this for initialization
	void Start () {
		cameraObject = GetComponent<Camera> ();
		cameraObject.clearFlags = CameraClearFlags.SolidColor;
	}
	
	// Update is called once per frame
	void Update () {

		float t = Mathf.PingPong(Time.time, duration) / duration;
		cameraObject.backgroundColor = Color.Lerp(color1, color2, t);

		
	}
}
