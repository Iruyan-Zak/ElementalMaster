using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KannaMotion : StateMachineBehaviour
{
    Rigidbody2D rigidbody;
    KannaOperation kannaOperation;

    [SerializeField]
    float speed = 0.6f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        rigidbody = animator.GetComponent<Rigidbody2D>();
        kannaOperation = animator.GetComponent<KannaOperation>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));
        animator.speed = kannaOperation.IsGrounded ? speed : 0;
    }
}
