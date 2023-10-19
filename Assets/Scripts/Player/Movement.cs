using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;

    [SerializeField]
    private float jumpForce = 3f;

    private Rigidbody2D playerRigidBody2D;

    private SpriteRenderer playerSprite;


    private void Start()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();

        playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        CharacterControl();
    }

    private void CharacterControl()
    {
        float input = Input.GetAxisRaw("Horizontal");
        Flip(input);
        if (playerRigidBody2D != null)
        {
            playerRigidBody2D.velocity = new Vector2(input * moveSpeed, playerRigidBody2D.velocity.y);
        }

        Jump();
    }

    private void Flip(float input)
    {
        if(playerSprite != null)
        {
            if (input > 0)
            {
                playerSprite.flipX = false;
            }
            else if (input < 0)
            {
                playerSprite.flipX = true;
            }
        }
        
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody2D.velocity = new Vector2(playerRigidBody2D.velocity.x, jumpForce);
        }
    }
}
