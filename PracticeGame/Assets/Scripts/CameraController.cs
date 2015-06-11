using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public PlayerController player;
	public bool isFollow;
	public float XOffset;
	public float YOffset;

	void Start () {
		player = FindObjectOfType<PlayerController>();
		isFollow = true;
	}

	void Update () {
		if(isFollow){
			transform.position = new Vector3(player.transform.position.x + XOffset, player.transform.position.y + YOffset, transform.position.z);
		}
	}
}
