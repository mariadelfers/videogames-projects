using UnityEngine;
using System.Collections;

public class AmmoBox : MonoBehaviour {

    public int ammo = 10;

    void OnTriggerEnter2D(Collider2D col)
    {
        //retrieve gun
        AmmoStorage ammoStorage = col.GetComponent<AmmoStorage>();
        //check if it exists
     if (ammoStorage != null)
        {
            ammoStorage.GiveAmmo(ammo);
            Destroy(gameObject);
        }
    }
}
