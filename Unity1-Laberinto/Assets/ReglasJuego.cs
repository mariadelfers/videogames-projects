using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReglasJuego : MonoBehaviour {

	public Text reloj;
	private float tiempoRestante;
    public bool meta = false;

	// Use this for initialization
	void Start () {
		tiempoRestante = 30.0f;
		transform.position = new Vector3 (9.3f, 1.0f, -8.45f);
	}
	
	// Update is called once per frame
	void Update () {
		tiempoRestante = tiempoRestante - Time.deltaTime;
		reloj.text = "Tiempo: " + tiempoRestante.ToString ("F0");
		if (tiempoRestante < 0 && meta == false) 
		{
			Start ();
		}
        if (meta == true)
        {
            reloj.text = "Tiempo:--";
        }	
	}
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("sensor"))
        {
            meta = true;
        }
    }
}
