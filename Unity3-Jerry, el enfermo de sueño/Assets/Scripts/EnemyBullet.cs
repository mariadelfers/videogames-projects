using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter2D (Collision2D target){
		if (target.gameObject.tag == "Plataform") {
			Destroy (gameObject);
		}
	}
}
