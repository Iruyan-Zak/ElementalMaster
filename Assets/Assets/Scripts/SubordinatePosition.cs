using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubordinatePosition : MonoBehaviour
{
    [SerializeField]
    GameObject Target;

    Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Target.transform.position + offset;
    }
}
