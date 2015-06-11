using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

	public float lifeTime;
	public GameObject impactEffect;

	void Start () {
	
	}

	void Update () {
		lifeTime -= Time.deltaTime;
		if(lifeTime < 0){
			Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}

	}
}
