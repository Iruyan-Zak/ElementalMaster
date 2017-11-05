using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour
{
    public float throwForce = 0.5f;

    Transform kanna;
    Transform holding;
    Animator animator;
    KannaOperation kannaOperation;

    // Use this for initialization
    void Start()
    {
        kanna = transform.parent;
        animator = kanna.GetComponent<Animator>();
        kannaOperation = kanna.GetComponent<KannaOperation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Hold") && holding != null)
        {
            GetComponent<Collider2D>().isTrigger = true;
            gameObject.layer = LayerMask.NameToLayer("Hold");

            releaseElement(holding);
            animator.SetBool("EmptyElement", true);

            holding = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Hold") && collision.tag == "Handy" && holding == null)
        {
            holding = collision.transform;
            holdElement(collision.transform);

            gameObject.layer = LayerMask.NameToLayer("Element");
            GetComponent<Collider2D>().isTrigger = false;

            animator.SetBool(holding.name, true);
        }
    }

    void holdElement(Transform element)
    {
        element.parent = kanna;
        element.localPosition = transform.localPosition;

        var rigidbody = element.GetComponent<Rigidbody2D>();

        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0f;
        rigidbody.simulated = false;
        kannaOperation.swapRigidbodyParameters(rigidbody);
    }

    void releaseElement(Transform element)
    {
        element.parent = null;

        var rigidbody = element.GetComponent<Rigidbody2D>();
        rigidbody.simulated = true;
        kannaOperation.swapRigidbodyParameters(rigidbody);

        rigidbody.AddForce(throwForce * kannaOperation.Direction * Vector2.right, ForceMode2D.Impulse);
    }
}
