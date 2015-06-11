using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {

	public float fireSpeed;
	public PlayerController player;
	public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	public int pointsForKill;
	public float rotationSpeed;
	public int damageToGive;

	void Start() {
		player = FindObjectOfType<PlayerController>();
		if(player.transform.localScale.x < 0){
			rotationSpeed = -rotationSpeed;
			fireSpeed = -fireSpeed;
		}
	}

	void Update() {
		GetComponent<Rigidbody2D>().velocity = new Vector2(fireSpeed, GetComponent<Rigidbody2D>().velocity.y);
		GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Enemy"){
			//Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy(other.gameObject);
			//ScoreManager.Add(pointsForKill);
			other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
		}
		Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
