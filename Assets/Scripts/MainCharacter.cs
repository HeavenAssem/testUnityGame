using UnityEngine;
using System.Collections;

public class MainCharacter : BaseUnit
{
	public float maxSpeed = 10f;
	public float jumpForce = 700f;
	bool isGrounded = false;
	bool lookRight = true;
	public float move;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start ()
	{

	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		move = Input.GetAxis ("Horizontal");
	}

	// Update is called once per frame
	override void Update ()
	{
		if (grounded && (Input.GetKeyDown (KeyCode.W)||Input.GetKeyDown (KeyCode.UpArrow))) {
			
			rigidbody2D.AddForce (new Vector2(0f,jumpForce));
		}

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

