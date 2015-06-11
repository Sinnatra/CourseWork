using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxPlayerHealth;
	public static int PlayerHealth;
	Text text;
	private LevelManager lvlManager;
	public bool isDead;

	void Start () {
		text = GetComponent<Text>();
		PlayerHealth = maxPlayerHealth;
		lvlManager = FindObjectOfType<LevelManager>();
		isDead = false;
	}

	void Update () {
		if(PlayerHealth <= 0 && !isDead){
			PlayerHealth = 0;
			lvlManager.RespawnPlayer();
			isDead = true;
		}
		text.text = "" + PlayerHealth;
	}

	public static void HurtPlayer(int damageToGive){
		PlayerHealth -= damageToGive;
	}

	public void FullHealth(){
		PlayerHealth = maxPlayerHealth;
	}
}
