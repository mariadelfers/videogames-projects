using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public int damage = 50;
  	void OnTriggerEnter2D(Collider2D col)
    {
        //get healt component
        EnemyHealth enemy = col.GetComponent<EnemyHealth>();
        //check if exists
        if (enemy != null)
        {
            enemy.OnHit(damage);
            Destroy(gameObject);
        }

        else if (col.GetComponent<MissileBlocker>())
        {
            Destroy(gameObject);
        }
    }
}
