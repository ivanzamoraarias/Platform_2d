using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	public Rigidbody2D ObjectRigidBody;

	public float moveSpeed;
	public float jumpHeight;

	// Use this for initialization
	void Start () {
		ObjectRigidBody.GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log ("Updated+++++++");
		if (Input.GetKey (KeyCode.Space)) 
		{
			Debug.Log ("Updated");
			ObjectRigidBody.velocity=new Vector2 (0,jumpHeight);
			//GetComponent<Rigidbody2D> ();
			//rigidbody2D.velocity = new Vector2 (0,jumpHeight);
		}
		
	}
}
