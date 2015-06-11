using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour {

	public int damageToGive;
	public float bounceOnEnemy;

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Enemy"){
			other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
			transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.parent.GetComponent<Rigidbody2D>().velocity.x, bounceOnEnemy);
		}
	}
}
