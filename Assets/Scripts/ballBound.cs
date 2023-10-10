using UnityEngine;

public class ballBound : MonoBehaviour
{
    [SerializeField] float randomFactor = 0.2f;

    //make the ball bounce in a random direction
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(randomFactor, randomFactor);
    }
}
