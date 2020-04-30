using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public Transform objetivo;
    private float distancia;
    private float distanciaMirar = 15.0f;
    private float distanciaAtacar = 8.0f;
    private float velocidadMov = 2.0f;
    private float retardo = 6.0f;
    public Renderer render; //cambio de color dependiendo de su estado de ánimo(semáforo)

	// Use this for initialization
	void Start () {
        render = GetComponent<Renderer>();
	}

    void mirar()
    {
        var rotation = Quaternion.LookRotation(objetivo.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * retardo);
    }

    void atacar()
    {
        transform.Translate(Vector3.forward * velocidadMov * Time.deltaTime); //Esto hace que nos persiga, foward por enfrente
    }

    // Update is called once per frame
    void Update () {
        distancia = Vector3.Distance(objetivo.position, transform.position);
        if (distancia < distanciaMirar)
        {
            render.material.color = Color.yellow; //Escoges el color
            mirar();
        }
        else
        {
            render.material.color = Color.green;
        }
        if (distancia < distanciaAtacar)
        {
            render.material.color = Color.red;
            atacar();
        }
	} 
}
