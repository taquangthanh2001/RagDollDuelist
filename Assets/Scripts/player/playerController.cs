using UnityEngine;

public class playerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public float jumpForce;
    public float playerSpeed;
    public Vector2 jumpHeight;
    private bool isOnGround;
    public float positionRadius;
    public LayerMask ground;
    public Transform playerPos;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public float kickSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
         
        for (int i = 0; i < colliders.Length; i++)
        {
            for(int j = i + 1; j < colliders.Length; j++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[j]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            if(Input.GetAxisRaw("Horizontal") > 0)
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
            anim.Play("Idle");
        }

        isOnGround = Physics2D.OverlapCircle(playerPos.position, positionRadius, ground);
        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("JUMPING");
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime);
        }
        
        //make player kick when k key z(right leg) or key c(left leg) pressed
        if (Input.GetKey(KeyCode.Z))
        {
            anim.Play("kickRight");
        }
        if (Input.GetKey(KeyCode.C))
        {
            anim.Play("kickLeft");
        }
    }
}
