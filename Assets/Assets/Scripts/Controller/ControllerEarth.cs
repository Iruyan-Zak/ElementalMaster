using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEarth : ControllerDefault
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        ResetVelocity();
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        ResetVelocity();
        rigidbody.AddForce(JumpForce * Vector2.up, ForceMode2D.Impulse);
    }

    protected override void Jump() { }

    void ResetVelocity()
    {
        var velocity = rigidbody.velocity;
        velocity.y = 0;
        rigidbody.velocity = velocity;
    }
}
