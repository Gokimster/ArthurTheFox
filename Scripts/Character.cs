using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public float maxSpeed = 10f;
	public bool facingRight = true;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 30;
	float move;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("ground", grounded);
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		Jump ();
		move = Input.GetAxis ("Horizontal");
		CheckHorizontalColission ();
		anim.SetFloat ("speed", Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if (move < 0 && facingRight)
			Flip ();
		else 
			if (move > 0 && !facingRight)
				Flip ();

	}

	//flip image
	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	//jump action 
	void Jump ()
	{
		if (grounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			anim.SetBool ("ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}

	}

	//beginning for checking collision with raycast
	void CheckHorizontalColission () {
		bool isColliding = false;
		RaycastHit hit;
		if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.left), out hit) || Physics.Raycast (transform.position, transform.TransformDirection(Vector3.right), out hit))
		{
			isColliding = true;
		}
			/*if(hit.transform.name.Contains("MovingPlatform"))
			{
				Transform movingPlatform  = hit.collider.transform;
				
				
			}*/
			
		if (isColliding) 
		{
			move = 0;
		}
			
	}

}
