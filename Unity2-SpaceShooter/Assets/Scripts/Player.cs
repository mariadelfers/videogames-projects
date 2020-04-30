using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 5f;
    private Rigidbody2D rigid;
    public GameOverScreen gameOverScreen;

    Vector3 min;
    Vector3 max;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        CalculateBounds();
	}

    void CalculateBounds()
    {
       Camera cam = Camera.main;
        Collider2D col = GetComponent<Collider2D>();
        Vector3 sizeBuffer = col.bounds.extents;
        //define min and max
        min = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)) + sizeBuffer;
        max = cam.ViewportToWorldPoint(new Vector3(1, 1, 0)) - sizeBuffer;
    }
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rigid.velocity = new Vector2(horizontal,vertical).normalized*speed;
        ClampPosition();

	}
    
    void ClampPosition()
    {
        
        //get intial position
        Vector3 endPostion = transform.position;
        //clamp positions
        endPostion.x = Mathf.Clamp(endPostion.x, min.x, max.x);
        endPostion.y = Mathf.Clamp(endPostion.y, min.y, max.y);
        //set position
        transform.position = endPostion;
    }

    public void Kill()
    {
        Destroy(gameObject);
        gameOverScreen.gameObject.SetActive(true);
    }

}
