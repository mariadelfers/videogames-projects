using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.Kill();
        }
    }

}
