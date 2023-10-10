using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] protected Transform hips;
    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
    }

    private void FixedUpdate()
    {
        var position = hips.position;
        _cam.transform.position = new Vector3
        {
            x = position.x,
            y = position.y,
            z = -10f
        };
    }
}