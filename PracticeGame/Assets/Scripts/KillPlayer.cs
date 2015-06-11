using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	public LevelManager lvlManager;

	void Start() {
		lvlManager = FindObjectOfType<LevelManager>();
	}

	void Update() {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "Player"){
			lvlManager.RespawnPlayer();
		}
	}
}
