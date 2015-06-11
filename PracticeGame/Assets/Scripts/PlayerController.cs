using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpHeight = 7.5f;
	public float moveSpeed = 3;
	private float moveVelocity;

	public Transform groundCheck;
	public float groundCheckRad;
	public LayerMask ground;
	private bool onground;
	private bool doubleJump;
	private Animator anim;
	public Transform firePoint;
	public GameObject fireBall;
	public float shotDelay;
	private float shotDelayCounter;
	public float knockBack;
	public float knockBackLength;
	public float knockBackCounter;
	public bool knockBackFromRight;

	void Start() {
		anim = GetComponent<Animator>();
	}

	void FixedUpdate(){
		onground = Physics2D.OverlapCircle(groundCheck.position, groundCheckRad, ground);
	}

	void Update() {
		#region HandlingData
		if(onground){
			doubleJump = false;
		}
		anim.SetBool("onGround", onground);
		if(Input.GetKeyDown(KeyCode.Space) && onground){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			Jump();
		}
		if(Input.GetKeyDown(KeyCode.Space) && !doubleJump && !onground){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			Jump();
			doubleJump = true;
		}
		moveVelocity = 0f;
		if(Input.GetKey(KeyCode.D)){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = moveSpeed;
		}
		if(Input.GetKey(KeyCode.A)){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = -moveSpeed;
		}
		#endregion

		if(knockBackCounter <= 0){
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
		} else {
			if(knockBackFromRight){
				GetComponent<Rigidbody2D>().velocity = new Vector2(-knockBack, knockBack);
			}
			if(!knockBackFromRight){
				GetComponent<Rigidbody2D>().velocity = new Vector2(knockBack, knockBack);
			}
			knockBackCounter -= Time.deltaTime;
		}

		anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		if(GetComponent<Rigidbody2D>().velocity.x > 0){
			transform.localScale = new Vector3(1f, 1f, 1f);
		}
		else if(GetComponent<Rigidbody2D>().velocity.x < 0){
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		if(Input.GetKeyDown(KeyCode.F)){
			Instantiate(fireBall, firePoint.position, firePoint.rotation);
			shotDelayCounter = shotDelay;
		}
		if(Input.GetKey(KeyCode.F)){
			shotDelayCounter -= Time.deltaTime;
			if(shotDelayCounter <= 0){
				shotDelayCounter = shotDelay;
				Instantiate(fireBall, firePoint.position, firePoint.rotation);
			}
		}
	}

	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
}
