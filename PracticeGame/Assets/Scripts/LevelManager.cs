using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public GameObject currentCheckpoint;
	private PlayerController player;
	public GameObject deathParticle;
	public GameObject respawnParticle;
	public int pointsResetOnDeath;
	public float respawnDelay;
	private CameraController cam;
	private float gravityStore;
	public HealthManager healthManager;
	
	void Start() {
		player = FindObjectOfType<PlayerController>();
		cam = FindObjectOfType<CameraController>();
		healthManager = FindObjectOfType<HealthManager>();
	}
	
	void Update() {
		
	}
	
	public void RespawnPlayer(){
		StartCoroutine("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		cam.isFollow = false;
		//gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
		//player.GetComponent<Rigidbody2D>().gravityScale = 0f;
		//player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		ScoreManager.Add(-pointsResetOnDeath);
		Debug.Log ("Player respawn!");
		yield return new WaitForSeconds(respawnDelay);
		//player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
		player.transform.position = currentCheckpoint.transform.position;
		player.knockBackCounter = 0;
		player.enabled = true;
		player.GetComponent<Renderer>().enabled = true;
		healthManager.FullHealth();
		healthManager.isDead = false;
		cam.isFollow = true;
		Instantiate(respawnParticle, player.transform.position, player.transform.rotation);
	}
}