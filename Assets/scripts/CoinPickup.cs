using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {


	public int pointsToAdd;

	void OnTriggerEnter2D(Collider2D o){
		if (o.GetComponent<player2d> () == null) 
			return; 
		ScoreManager.AddPoints (pointsToAdd);

		Destroy (gameObject);
		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
