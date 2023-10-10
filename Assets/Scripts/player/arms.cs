using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arms : MonoBehaviour
{
    int speed = 300;
    public Rigidbody2D rb;
    public Camera cam;
    public KeyCode mouseButton;

    void Update()
    {
        Vector3 playerPos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, 
                                        cam.ScreenToWorldPoint(Input.mousePosition).y, 0);
        Vector3 difference = playerPos - transform.position;
        float rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;
        if(Input.GetKey(mouseButton))
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, rotationZ, speed * Time.fixedDeltaTime));
        }
    }
}
