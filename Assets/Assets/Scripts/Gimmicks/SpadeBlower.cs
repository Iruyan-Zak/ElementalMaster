using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadeBlower : MonoBehaviour
{
    [SerializeField]
    float windLength = 10;
    [SerializeField]
    float windForce = 10;

    private void FixedUpdate()
    {
        var start = (Vector2)transform.position + (Vector2)transform.up;
        var end = start + windLength * (Vector2)transform.up;
        var hit = Physics2D.Linecast(start, end);
        if (hit && hit.transform.gameObject.tag == "Kanna")
        {
            hit.transform.GetComponent<Rigidbody2D>().AddForce(
            (1 + windLength - Vector2.Distance(transform.position, hit.transform.position)) / windLength
            * windForce * transform.up);
        }
    }
}
