using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;
	public int pointsOnDeath;
	public GameObject deathEffect;
	
	void Start () {
	
	}

	void Update () {
		if(enemyHealth <= 0){
			Instantiate(deathEffect, transform.position, transform.rotation);
			ScoreManager.Add(pointsOnDeath);
			Destroy(gameObject);
		}
	}

	public void giveDamage(int damageToGive){
		enemyHealth -= damageToGive;
	}
}
