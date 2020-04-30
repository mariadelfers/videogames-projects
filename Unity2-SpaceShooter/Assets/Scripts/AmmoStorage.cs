using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AmmoStorage : MonoBehaviour {

    private int ammoCount = 10;
    public Text ammoLabel;

	void Start () {
        UpdateAmmoText();
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

    public bool ConsumeAmmo (int ammoToUse)
    {
        if (ammoCount >= ammoToUse)
        {
            ammoCount -= ammoToUse;
            UpdateAmmoText();
            return true;
        }
        return false;
    }
}
