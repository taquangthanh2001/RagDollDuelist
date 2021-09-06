using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollEnemyWalk : MonoBehaviour
{
    public GameObject target;
    public float dist;
    public GameObject hips;
    public bool onRight;
    public bool inRange;
    public Animator anim;
    public Rigidbody2D rb;
    public int enemySpeed = 6;
    public float distToPlayer;
    
    void Update()
    {
        dist = Vector2.Distance(target.transform.position, hips.transform.position);
        if(target.transform.position.x < hips.transform.position.x)
        {
            onRight = true;
        }
        else
        {
            onRight = false;
        }
        if(dist > 0)
        {
            inRange = false;
            if(onRight)
            {
                anim.Play("WalkBack");
                rb.AddForce(Vector2.left * enemySpeed);
            }
            else
            {
                anim.Play("Walk");
                rb.AddForce(Vector2.right * enemySpeed);
            }    
        }
        else
        {
            inRange = true;
            anim.Play("Idle");
        }
    }
}
