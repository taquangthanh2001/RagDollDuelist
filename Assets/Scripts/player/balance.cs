using UnityEngine;

public class balance : MonoBehaviour
{
    public float targetRotation;
    public Rigidbody2D rb;
    public float force;

    public void Update()
    {
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, force * Time.fixedDeltaTime));
    }
}
