using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arms : MonoBehaviour
{
    int speed = 300;
    private Rigidbody2D _rb;
    [SerializeField] protected KeyCode mouseButton;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 playerPos = JoyStick.Instance.joystickVecMove;
        Vector3 difference = playerPos - (Vector3)JoyStick.Instance.joystickVecDf;
        float rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;
        if (Input.GetKey(mouseButton))
        {
            _rb.MoveRotation(Mathf.LerpAngle(_rb.rotation, rotationZ, speed * Time.fixedDeltaTime));
        }
    }
}