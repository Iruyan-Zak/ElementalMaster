using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondLift : MonoBehaviour
{
    float OriginY;
    public float SpringCoef = 2;
    public float DumperCoef = 2;

    new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        OriginY = rigidbody.mass * 10 /* 重力加速度 */ / SpringCoef + transform.position.y;
    }

    private void FixedUpdate()
    {
        var force = (OriginY - transform.position.y) * SpringCoef;
        force -= rigidbody.velocity.y * DumperCoef;
        rigidbody.AddForce(force * Vector2.up);
    }
}
