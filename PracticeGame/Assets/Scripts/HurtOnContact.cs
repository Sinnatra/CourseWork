using UnityEngine;
using System.Collections;

public class HurtOnContact : MonoBehaviour {

	public int damageToGive;

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "Player"){
			HealthManager.HurtPlayer(damageToGive);
			var player = other.GetComponent<PlayerController>();
			player.knockBackCounter = player.knockBackLength;
			if(other.transform.position.x < transform.transform.position.x){
				player.knockBackFromRight = true;
			} else {
				player.knockBackFromRight = false;
			}
		}
	}
}
