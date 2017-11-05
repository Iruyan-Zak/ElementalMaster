using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KannaMotion : StateMachineBehaviour
{
    Rigidbody2D rigidbody;
    KannaOperation kannaOperation;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        rigidbody = animator.GetComponent<Rigidbody2D>();
        kannaOperation = animator.GetComponent<KannaOperation>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetFloat("Speed", kannaOperation.IsGrounded ? Mathf.Abs(rigidbody.velocity.x) : 0);
    }
}
