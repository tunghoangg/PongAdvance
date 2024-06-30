using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private bool player1;
    [SerializeField] private bool player2;

    GameObject ball;
    private Rigidbody2D rb;
    private Vector2 playerMove;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        if (isAI)
        {
            AIControl();
        }
        else if (player1)
        {
            Player1Control();
        }
        else if (player2)
        {
            Player2Control();
        }
        else
        {
            PlayerControl();
        }
        
    }

    private void Player2Control()
    {
        playerMove = new Vector2(0, Input.GetAxisRaw("VerticalP2"));
    }

    private void Player1Control()
    {
        playerMove = new Vector2(0, Input.GetAxisRaw("VerticalP1"));
    }

    private void PlayerControl()
    {
        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical")) ;
    }
    private void AIControl()
    {
        if(ball != null)
        {
            if (ball.transform.position.y > transform.position.y + 0.5f)
            {
                playerMove = new Vector2(0, 1);
            }
            else if (ball.transform.position.y < transform.position.y - 0.5f)
            {
                playerMove = new Vector2(0, -1);
            }
            else
            {
                playerMove = Vector2.zero;
            }
        }
        else
        {
            playerMove = Vector2.zero;
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = playerMove * moveSpeed;
    }
}
