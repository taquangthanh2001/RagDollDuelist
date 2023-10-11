using Base;
using UnityEngine;

namespace Player
{
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

        internal float timeCdJump = -1f;
        internal bool isJumpBar = true;

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
                anim.Play($"idle");
            }
            base.MoveByTarget();
        }

        protected override void Jump()
        {
            _isOnGround = Physics2D.OverlapCircle(playerPos.position, positionRadius, ground);
            if (movementJoystick.joystickVecMove.y > movementJoystick.joystickVecDf.y
                && _isOnGround && (timeCdJump < 0) && isJumpBar
               )
            {
                JumpBarPlayer.Instance.SetStatusActiveJumpBar(JumpBarPlayer.StatusJump.ToJump);
            }
            if (movementJoystick.joystickVecMove.y < movementJoystick.joystickVecDf.y)
                JumpBarPlayer.Instance.SetStatusActiveJumpBar(JumpBarPlayer.StatusJump.Cancel);


            if (!(timeCdJump > 0)) return;
            timeCdJump -= Time.deltaTime;
            isJumpBar = true;
        }

        public Vector3 GetPlayerPos()
        {
            return rb.transform.position;
        }

        internal void Jumping()
        {
            rb.AddForce(Vector2.up * (jumpForce * Time.deltaTime));
        }
    }
}