using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currectCheckPoint;
	private player2d player;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnDelay;

	public int pointPenaltyForDeath;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<player2d> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCorutineFunction");
		/*Instantiate (deathParticle,player.transform.position,player.transform.rotation);

		player.transform.position = currectCheckPoint.transform.position;
		Instantiate (respawnParticle,player.transform.position,player.transform.rotation);
		Debug.Log ("Player Respawned (*_*)");
		*/
	}

	public IEnumerator RespawnPlayerCorutineFunction()
	{
		Instantiate (deathParticle,player.transform.position,player.transform.rotation);


		player.enabled = false;
		player.setRenderization (false);
		player.ObjectRigidBody.velocity = Vector2.zero;
		ScoreManager.AddPoints (-pointPenaltyForDeath);

		yield return new WaitForSeconds (respawnDelay);
		player.transform.position = currectCheckPoint.transform.position;

		player.enabled = true;
		player.setRenderization (true);
		Instantiate (respawnParticle,player.transform.position,player.transform.rotation);
		Debug.Log ("Player Respawned (*_*)");
	}
}
