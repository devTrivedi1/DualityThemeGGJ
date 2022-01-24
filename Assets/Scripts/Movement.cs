using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private float horizontalMovement;
	private float veritcalMovement;

	[SerializeField] private float moveSpeed;

	private Rigidbody2D playerRB;

	private Vector2 currentVelocity;

	void Start()
	{
		playerRB = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		ReadInputs();
	}
	void FixedUpdate()
	{
		MovePlayer();
	}

	void ReadInputs()
	{
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
}
