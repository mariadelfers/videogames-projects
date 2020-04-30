using UnityEngine;
using System.Collections;

public class AudioZone : MonoBehaviour
{
	private string colisionador;
	void OnTriggerEnter (Collider other)
	{
		colisionador = other.tag;
		if (colisionador == "Player")
		{
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().loop = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		colisionador = other.tag;
		if (colisionador == "Player")
		{
			GetComponent<AudioSource> ().Stop ();
			GetComponent<AudioSource>().loop = false;
		}
	}
}
