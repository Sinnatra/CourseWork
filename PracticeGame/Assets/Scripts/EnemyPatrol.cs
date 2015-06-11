using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed = 1.3f;
	public bool moveRight;
	public Transform wallCheck;
	public float wallCheckRad;
	public LayerMask walls;
	private bool hitingTheWalls;
	private bool atEdge;
	public Transform edgeCheck;

	void Start () {
	
	}

	void Update () {
		hitingTheWalls = Physics2D.OverlapCircle(wallCheck.position, wallCheckRad, walls);
		atEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRad, walls);
		if(hitingTheWalls || !atEdge){
			moveRight = !moveRight;
		}
		if(moveRight){
			transform.localScale = new Vector3(-1f, 1f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		} else {
			transform.localScale = new Vector3(1f, 1f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
	}
}
