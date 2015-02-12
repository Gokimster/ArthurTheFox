using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	public float maxSpeed = 1f;
	public float moveRadius = 10f;
	float distanceToOrigin =0;
	public bool startToRight = true;
	float move;
	// Use this for initialization
	void Start () {
		if (startToRight)
			move = 1;
		else 
			move = -1;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (distanceToOrigin > moveRadius)
			move = -1;
		else
			if (distanceToOrigin < -moveRadius)
			move = 1;
		
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		distanceToOrigin += move * maxSpeed;
	}
}
