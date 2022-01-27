using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2DPatrol : MonoBehaviour
{
    [SerializeField, Range(0, 100)] 
    float patrolSpeed = 10f;

    [SerializeField, Range(0, 100)]
    float distance = 2f;

    bool moveRight = true;

    public Transform groundCheck;
    public Transform wallCheck;

    public LayerMask groundMask;
    public LayerMask wallMask;

    void Update()
    {
        transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, distance, groundMask);
        RaycastHit2D wallInfo = Physics2D.Raycast(wallCheck.position, Vector2.right, distance, wallMask);

        if (groundInfo.collider == false || wallInfo.collider == true)
        {
            //Checks if the enemy agent is oriented in the right (aka Forward) direction and makes them face the opposite direction
            if (moveRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            //And vice versa if they're facing the left direction.
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
    }
}