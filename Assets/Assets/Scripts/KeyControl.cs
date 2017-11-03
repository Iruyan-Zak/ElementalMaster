using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    public float force = 10;
    public float jumpForce = 5;
    public float maxSpeed = 2.5f;

    float distToGround;
    int groundMask;

    new Rigidbody2D rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        groundMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var dx = Input.GetAxis("Horizontal");
        if (rigidbody.velocity.x * Mathf.Sign(dx) < maxSpeed)
        {
            rigidbody.AddForce(force * new Vector2(dx, 0));
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.1f, groundMask);
    }
}
