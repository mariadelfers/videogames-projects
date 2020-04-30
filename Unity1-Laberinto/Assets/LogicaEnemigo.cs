using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogicaEnemigo : MonoBehaviour {

    private int energia = 50;
	
	// Update is called once per frame
	void Update () {
	    if (energia <= 0)
        {
            Destroy(gameObject); //Destruir game obj con la condición
            SceneManager.LoadScene("Scene2");

        }
	}
    
    void ApplyDamage(int damage)
    {
        energia = energia - damage;
    } 
}
