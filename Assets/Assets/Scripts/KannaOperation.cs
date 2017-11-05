using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KannaOperation : MonoBehaviour
{
    new Rigidbody2D rigidbody;

    float distToGround;
    int groundMask;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        groundMask = LayerMask.GetMask("Ground");
    }

    public float Direction
    {
        get
        {
            return Mathf.Sign(90 - transform.rotation.eulerAngles.y);
        }

        set
        {
            transform.rotation = Quaternion.Euler(90 * (1 - Mathf.Sign(value)) * Vector3.up);
        }
    }

    public bool IsGrounded
    {
        get
        {
            return Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.1f, groundMask);
        }
    }



    public void swapRigidbodyParameters(Rigidbody2D other)
    {
        var mass = rigidbody.mass;
        rigidbody.mass = other.mass;
        other.mass = mass;

        var gravityScale = rigidbody.gravityScale;
        rigidbody.gravityScale = other.gravityScale;
        other.gravityScale = gravityScale;
    }
}