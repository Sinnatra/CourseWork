using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public int pointToAdd;
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.GetComponent<PlayerController>() == null){
			return;
		}
		ScoreManager.Add(pointToAdd);
		Destroy(gameObject);
	}
}
