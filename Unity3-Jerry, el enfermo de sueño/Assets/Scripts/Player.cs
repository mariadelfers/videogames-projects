using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Animator anim;

	bool facingRight = true;
	public float maxSpeed = 5f;

	public float jumpForce = 150f;
	bool grounded = true;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public Transform groundCheck;



	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();

	}

	void FixedUpdate(){
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("speed", Mathf.Abs (move));
		rb2d.velocity = new Vector2 (move * maxSpeed, rb2d.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("ground",true);
	}

	void Update(){
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			rb2d.AddForce (new Vector2 (0, jumpForce));
			anim.SetBool ("ground", false);
		}
			
	}
	
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void LoadByIndex(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Enemy") {
			anim.SetTrigger ("die");
		} 
		if (col.gameObject.tag == "Exit") {
			LoadByIndex (4);	
		}
		
	}

	public void Die(){
		this.gameObject.SetActive (false);
		Invoke ("ResetLevel", 1);
	}

	void ResetLevel(){
		SceneManager.LoadScene ("level1");
	}
}
