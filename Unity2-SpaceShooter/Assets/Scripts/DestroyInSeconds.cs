using UnityEngine;
using System.Collections;

public class DestroyInSeconds : MonoBehaviour {

    public float lifeTime = 5;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeTime);
	}
	
}
