using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int health = 100;
    public int scoreValue = 50;
    public GameObject toSpawnOnDeath;

    public SpriteRenderer sprite;
    private int startingHealth; 
    public AnimationCurve damageCurve;
    public bool isBoss = false;

    void Start()
    {
        
     // startingHealth = health;
     // if (Sprite != null)
     // {
     //     Color c = Sprite.color;
     //     c.a = 0;
     //     Sprite.color = c;
     // }
        if (isBoss)
        {
            foreach (Spawner s in FindObjectOfType<Spawner>())
            {
                s.OnBossSpawned();
            }
        }
    }

    public void OnHit (int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Kill();
        }
    }
   
        public void Kill()
        {
            Destroy(gameObject);
            if(toSpawnOnDeath != null)
        {
            Instantiate(toSpawnOnDeath, transform.position, transform.rotation);
        }
            ScoreManager manager = FindObjectOfType<ScoreManager>();
            if (manager != null)
            {
            manager.AddScore(scoreValue);    
            }
            else
            {
            Debug.LogError("No Score Manager Found, not adding score");    
            }
        if (isBoss)
            foreach (Spawner s in FindObjectOfType<Spawner>())
            {
                s.OnBossKilled();
            }
    }
    
}
