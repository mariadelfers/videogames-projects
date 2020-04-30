using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Animator anim;
	bool facingLeft = true;
//	private bool time = false;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float move = rb2d.velocity.x;
		anim.SetFloat ("speed", Mathf.Abs (move));

		if (move < 0 && !facingLeft)
			Flip ();
		else if (move > 0 && facingLeft)
			Flip ();
	}

	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
