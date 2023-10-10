using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    public Animator anim;
    public Rigidbody2D rb;
    public float jumpForce;
    public float playerSpeed;
    private bool isOnGround;
    public float positionRadius;
    public LayerMask ground;
    public Transform playerPos;
    public JoyStick movementJoystick;

    protected override void MoveByTarget()
    {
        if (movementJoystick.joystickVec.y != 0)
        {
            if (movementJoystick.joystickVecMove.x > movementJoystick.joystickVecDf.x)
            {
                anim.Play("Walk");
                rb.AddForce(Vector2.right * playerSpeed * Time.deltaTime);
            }
            else
            {
                anim.Play("WalkBack");
                rb.AddForce(Vector2.left * playerSpeed * Time.deltaTime);
            }
        }
        else
        {
            anim.Play("idle");
        }

        // if(Input.GetAxisRaw("Horizontal") != 0)
        // {
        //     if(Input.GetAxisRaw("Horizontal") > 0)
        //     {
        //         anim.Play("Walk");
        //         rb.AddForce(Vector2.right * playerSpeed * Time.deltaTime);
        //     }
        //     else
        //     {
        //         anim.Play("WalkBack");
        //         rb.AddForce(Vector2.left * playerSpeed * Time.deltaTime);
        //     }
        // }
        // else
        // {
        //     anim.Play("Idle");
        // }
        base.MoveByTarget();
    }

    protected override void Jumb()
    {
        // if (movementJoystick.joystickVec.y > movementJoystick.joystickVecDf.y)
        // {
        //     timeCdJumb -= Time.deltaTime;
        //     if (timeCdJumb < 0 & isJumb)
        //     {
        //         leftLegRB.AddForce(Vector2.up * (jumpHeight * 1000));
        //         rightLegRB.AddForce(Vector2.up * (jumpHeight * 1000));
        //         isJumb = false;
        //     }
        // }
        isOnGround = Physics2D.OverlapCircle(playerPos.position, positionRadius, ground);
        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime);
        }
    }
}