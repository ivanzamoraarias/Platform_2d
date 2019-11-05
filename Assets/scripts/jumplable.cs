using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class jumplable : MonoBehaviour 
{
	public float speed = 600.0f;
	public float jumpSpeed = 900.0f;
	public float gravity = Physics.gravity.y;

	private Vector3 moveDirection = Vector3.zero;
	private bool grounded = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log ("Updating"+gravity);
		if (grounded) 
		{
			Debug.Log ("In the if");
			moveDirection = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			if (Input.GetButton ("Jump")) 
			{
				Debug.Log ("jumping lof ........");
				moveDirection.y = jumpSpeed;
			}
		}

		Debug.Log ("Doing other stuff");

		// Apply gravity
	
		moveDirection.y += gravity * Time.deltaTime;

		//Debug.Log ("holaaa");

		// Move the controller
		CharacterController controller = (CharacterController)GetComponent(typeof(CharacterController));
		CollisionFlags flags = controller.Move(moveDirection * Time.deltaTime);
	    grounded = (flags  & CollisionFlags.CollidedBelow) != 0;
	}

}
