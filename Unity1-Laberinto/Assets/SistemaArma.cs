using UnityEngine;
using System.Collections;

public class SistemaArma : MonoBehaviour {

    private int damage = 10;
    public float distancia;
    public float distMax = 2.0f; //La distancia va del centro del personaje al centro del enemigo
    public Transform Jugador;

	// Update is called once per frame
	void Update () {
        //Como activar el ataque
        if (Input.GetButtonDown("Fire1")) //Fire1 boton izq del mouse
        {
            GetComponent<Animation>().Play("atacar"); //atacar es la animación designada
         }
	}

    void Attack()
    {
        RaycastHit hit; //intentos de golpe
        //Validar el golpe, si estamos de frente
        if(Physics.Raycast(Jugador.transform.position, Jugador.transform.TransformDirection (Vector3.forward), out hit))
        {
            distancia = hit.distance;
            if(distancia < distMax)
            {
                //Manda mensaje de daño
                hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
