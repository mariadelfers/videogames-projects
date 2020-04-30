using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public Transform target;
	Vector3 velocity = Vector3.zero;
	public float smoothTime = .15f;

	public float Xmin = 0;
	public float Xmax = 0;
	public float Ymin = 0;
	public float Ymax = 0;

	public bool XminEnable = false;
	public bool XmaxEnable = false;
	public bool YminEnable = false;
	public bool YmaxEnable = false;


	void FixedUpdate(){
		Vector3 targetPos = target.position;
		if (YminEnable && YmaxEnable)
			targetPos.y = Mathf.Clamp (target.position.y, Ymin, Ymax);
		else if (YminEnable)
			targetPos.y = Mathf.Clamp (target.position.y, Ymin, target.position.y);
		else if (YmaxEnable)
			targetPos.y = Mathf.Clamp (target.position.y, target.position.y, Ymax);
	
		if (XminEnable && XmaxEnable)
			targetPos.x = Mathf.Clamp (target.position.x, Xmin, Xmax);
		else if (XminEnable)
			targetPos.x = Mathf.Clamp (target.position.x, Xmin, target.position.x);
		else if (XmaxEnable)
			targetPos.x = Mathf.Clamp (target.position.x, target.position.x, Xmax);

		targetPos.z = transform.position.z;
		transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, smoothTime);
	}
}
