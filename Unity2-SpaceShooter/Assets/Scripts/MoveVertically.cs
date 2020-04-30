using UnityEngine;
using System.Collections;

public class MoveVertically : MonoBehaviour {

    private Rigidbody2D rigid;

    public float speed = 8f;
    public float strafeSpeed = 0f;
    public float strafeRange = 0f;

    private float startingStrafePos;
    private float currentStrafeAmount;

    public float minYPosition = -1000;
    public bool useWorldDirection = false;


    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        startingStrafePos = transform.position.x;
        currentStrafeAmount = strafeRange;
	}
	
	// Update is called once per frame
	void Update () {

        if (strafeRange != 0)
        {

            //find current pos
            Vector3 strafePos = transform.position;
            //update strafe position
            currentStrafeAmount = currentStrafeAmount + Time.deltaTime * strafeSpeed;
            //ping the value so it is consistantly in our range
            float xPos = Mathf.PingPong(currentStrafeAmount, strafeRange * 2) - strafeRange;
            //add the starting point
            xPos += startingStrafePos;
            //set the position
            transform.position = strafePos;
        }

        Vector3 clampYPos = transform.position;
        clampYPos.y = Mathf.Max(minYPosition, clampYPos.y);
        transform.position = clampYPos;

        if (useWorldDirection)
        {
            rigid.velocity = Vector3.up * speed;
        }
        else
        {
            // rigid.velocity = transform.up * speed;
            rigid.velocity = new Vector2(0, speed);
        }
    }
}

