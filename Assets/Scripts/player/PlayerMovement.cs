using Player;
using UnityEngine;

public class PlayerMovement : Movement
{
    public Animator anim;
    public Rigidbody2D rb;
    public float jumpForce;
    public float playerSpeed;
    private bool _isOnGround;
    public float positionRadius;
    public LayerMask ground;
    public Transform playerPos;
    public JoyStick movementJoystick;

    protected static PlayerMovement instance;

    public static PlayerMovement Instance
    {
        get => instance;
        protected set { value = instance; }
    }

    protected override void Start()
    {
        base.Start();
        if (instance == null)
        {
            instance = this;
        }
    }

    protected override void MoveByTarget()
    {
        if (movementJoystick.joystickVec.y != 0)
        {
            if (movementJoystick.joystickVecMove.x > movementJoystick.joystickVecDf.x)
            {
                anim.Play("Walk");
                rb.AddForce(Vector2.right * (playerSpeed * Time.deltaTime));
            }
            else
            {
                anim.Play("WalkBack");
                rb.AddForce(Vector2.left * (playerSpeed * Time.deltaTime));
            }
        }
        else
        {
            anim.Play("idle");
        }

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

        // if (Input.GetKeyDown(KeyCode.Space))
        //     JumpBarPlayer.Instance.SetStatusActiveJumpBar(true);
        // if (JumpBarPlayer.Instance.isJump)
        // {
        //     rb.AddForce(Vector2.up * (jumpForce * Time.deltaTime));
        // }

        _isOnGround = Physics2D.OverlapCircle(playerPos.position, positionRadius, ground);
        if (_isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * (jumpForce * Time.deltaTime));
        }
    }

    public Vector3 GetPlayerPos()
    {
        return rb.transform.position;
    }
}