using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Text reloj;
	private float tiempoRestante;

	// Use this for initialization
	void Start () {
		tiempoRestante = 30.0f;
	}

	// Update is called once per frame
	void Update () {
		tiempoRestante = tiempoRestante - Time.deltaTime;
		reloj.text = "Tiempo: " + tiempoRestante.ToString ("F0");
		if (tiempoRestante < 0) 
		{
			Invoke ("ResetLevel", 0);
		}
	}
		
	void LoadByIndex (int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}
	void ResetLevel(){
		SceneManager.LoadScene ("level1");
	}
}
