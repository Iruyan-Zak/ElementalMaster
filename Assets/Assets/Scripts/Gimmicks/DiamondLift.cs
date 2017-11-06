using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondLift : MonoBehaviour
{
    float springCoef;
    float originY;
    public float hardness = 1;

    new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        springCoef = hardness * Mathf.Sqrt(rigidbody.drag) * rigidbody.mass;
        originY = -rigidbody.mass * rigidbody.gravityScale * Physics2D.gravity.y / springCoef + transform.position.y;
    }

    private void FixedUpdate()
    {
        var force = (originY - transform.position.y) * springCoef;
        rigidbody.AddForce(force * Vector2.up);
    }
    /*
    private void Update()
    {
        var position = transform.position;
        position.y = Mathf.Min(position.y, limitY);
        transform.position = position;
    }*/
}
