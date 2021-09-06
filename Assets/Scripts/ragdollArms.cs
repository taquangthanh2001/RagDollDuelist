using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollArms : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    public GameObject player;
    public bool onRight;
    public bool rightArm;
    public Transform body;
    void Update()
    {
        player = transform.parent.GetComponent<ragdollEnemyWalk>().target;
        if(transform.parent.GetComponent<ragdollEnemyWalk>().inRange)
        {
            if(!rightArm && transform.parent.GetComponent<ragdollEnemyWalk>().onLeft)
            {
                Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
                Vector3 diff = playerPos - transform.position;
                float rotationZ = Mathf.Atan2(diff.x, -diff.y) * Mathf.Rad2Deg;
                rb.MoveRotation(Mathf.LerpAngle(rb.rotation, rotationZ, force * Time.fixedDeltaTime));
            }
            if (rightArm && transform.parent.GetComponent<ragdollEnemyWalk>().onLeft == false)
            {
                Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
                Vector3 diff = playerPos - transform.position;
                float rotationZ = Mathf.Atan2(diff.x, -diff.y) * Mathf.Rad2Deg;
                rb.MoveRotation(Mathf.LerpAngle(rb.rotation, rotationZ, force * Time.fixedDeltaTime));
            }
        }
    }
}
