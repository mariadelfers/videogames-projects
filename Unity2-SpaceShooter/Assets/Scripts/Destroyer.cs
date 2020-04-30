using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Destroyer>() == null)
        {
            Destroy(col.gameObject);
        }
    }
}

