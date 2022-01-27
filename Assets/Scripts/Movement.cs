using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private float horizontalMovement;
	private float veritcalMovement;

	[SerializeField] private float moveSpeed;
	

	private Rigidbody2D playerRB;


	private bool hasJumped;
	[SerializeField]private bool isGrounded = true;

	private Vector2 currentVelocity;
	[SerializeField] float jumpForce;
	void Start()
	{
		isGrounded = GameObject.FindGameObjectWithTag("Ground");
		playerRB = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		ReadInputs();
	}
	void FixedUpdate()
	{
		MovePlayer();
		if(hasJumped)
		{
			Jump();
			hasJumped = false;
			isGrounded = false;
		}
	}

	void ReadInputs()
	{
		if(Input.GetButtonDown("Jump") && isGrounded == true)
		{
			hasJumped = true;
		}

		horizontalMovement = Input.GetAxis("Horizontal");
		veritcalMovement = Input.GetAxis("Vertical");

		currentVelocity = this.playerRB.velocity;

	}

	void MovePlayer()
	{
		if (horizontalMovement != 0)
		{
			playerRB.velocity = new Vector2(horizontalMovement * moveSpeed, currentVelocity.y);
		}
	}
	
	void Jump()
	{
		if(hasJumped && isGrounded)
		{
			playerRB.velocity = Vector2.up * jumpForce;
		}
	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Ground"))
		{
			isGrounded = true;	
		}
	}
}
