﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2d : MonoBehaviour {

	public Rigidbody2D ObjectRigidBody;

	public float moveAcceleration;
	public float jumpHeight;

	private float moveVelocity;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;

	private Animator animatorObjet;
	private Renderer renderObject;


	// Use this for initialization
	void Start () {
		ObjectRigidBody = GetComponent<Rigidbody2D> ();
		animatorObjet = GetComponent<Animator> ();
		renderObject = GetComponent<Renderer> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Updated+++++++"+ Time.deltaTime);
		//Vector2 resultingVector= new Vector2(0,0);
		if (grounded)
			doubleJumped = false;

		animatorObjet.SetBool ("Grounded",grounded);

		if (Input.GetKeyDown (KeyCode.Space) && grounded) 
		{
			Jump();

		}
		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded) 
		{
			Jump();
			doubleJumped = true;
		}

		moveVelocity = 0f;
		if (Input.GetKey (KeyCode.RightArrow)) 
		{

			//ObjectRigidBody.velocity=new Vector2 (moveAcceleration,ObjectRigidBody.velocity.y);
			moveVelocity=moveAcceleration;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			moveVelocity = -moveAcceleration;
			//ObjectRigidBody.velocity=new Vector2 (-moveAcceleration,ObjectRigidBody.velocity.y);
		}
		//ObjectRigidBody.velocity += resultingVector;
		ObjectRigidBody.velocity= new Vector2 (moveVelocity, ObjectRigidBody.velocity.y);

		animatorObjet.SetFloat ("Speed",Mathf.Abs(ObjectRigidBody.velocity.x));

		//float currentX = Mathf.Abs(transform.localScale.x);

		/*Vector3 scaleVector = transform.localScale;

		if (ObjectRigidBody.velocity.x > 0) {
			transform.localScale = new Vector3 (10,10,1);
			//transform.localScale.x = currentX;
		} else if (ObjectRigidBody.velocity.x < 0) {
			transform.localScale = new Vector3 (-10,10,1);	
			//transform.localScale.x = -currentX;
		}*/
	}

	void FixedUpdate()
	{
		Debug.Log ("Fixed Update");
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		Debug.Log (grounded);
	}

	private void Jump()
	{
		ObjectRigidBody.velocity=new Vector2 (ObjectRigidBody.velocity.x,jumpHeight);
	}

	public void setRenderization(bool v)
	{
		renderObject.enabled = v;
	}

}
