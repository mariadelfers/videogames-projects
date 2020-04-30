using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gun : MonoBehaviour {

    private int ammoCount = 10;
    public GameObject toShoot;
    public AudioSource gunNoise;
    public bool isAutoFire = false;
    public int ammoConsumation = 1;

    public string buttonKey = "Fire1";

    public Text ammoLabel;
    public Transform[] firePoint;

    private AmmoStorage ammo;

    public float fireSpeed = 0.25f;
    private float tillNextFire = 0;

    // Use this for initialization
	void Start ()
    {
        ammo = FindObjectOfType<AmmoStorage>();
	}
	
	// Update is called once per frame
	void Update () {

        if (tillNextFire > 0)
        {
            tillNextFire -= Time.deltaTime;
            return;
        }
        if ((isAutoFire&&Input.GetButton(buttonKey))||Input.GetButtonDown(buttonKey))
        {
            if (ammo.ConsumeAmmo(ammoConsumation))
            {
                //foreach podemos aumentar lo que queramo, en este caso el arma
                foreach (Transform t in firePoint)
                {
                    Instantiate(toShoot, t.position, t.rotation);
                }

                tillNextFire = fireSpeed;

                if (gunNoise != null)
                {
                    gunNoise.Play();
                }
             // ammoCount--;
             // UpdateAmmoText();
            }
        }
	}

    void UpdateAmmoText()
    {
        ammoLabel.text = "Ammo: " + ammoCount;
    }

    public void GiveAmmo(int ammoToGive)
    {
        ammoCount += ammoToGive;
        UpdateAmmoText();
    }
}
