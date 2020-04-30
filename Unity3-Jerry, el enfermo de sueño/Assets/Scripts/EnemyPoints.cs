using UnityEngine;
using System.Collections;

public class EnemyPoints : MonoBehaviour {

	public float velocity = 1f;

	public Transform sightStart;
	public Transform sightEnd;
	public bool colliding;
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		Physics2D.queriesStartInColliders = true;
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (velocity, GetComponent<Rigidbody2D>().velocity.y);
		colliding = Physics2D.Linecast (sightStart.position, sightEnd.position);
		if (colliding) {
			transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
			velocity*= -1;
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine (sightStart.position, sightEnd.position);
	}
}

