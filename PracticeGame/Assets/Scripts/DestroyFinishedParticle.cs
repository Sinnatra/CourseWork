using UnityEngine;
using System.Collections;

public class DestroyFinishedParticle : MonoBehaviour {

	private ParticleSystem ps;

	void Start() {
		ps = GetComponent<ParticleSystem>();
	}

	void Update() { 
		if(ps.isPlaying){
			return;
		}
		Destroy(gameObject);
	}

	void OnBecamInvisible(){
		Destroy(gameObject);
	}
}
