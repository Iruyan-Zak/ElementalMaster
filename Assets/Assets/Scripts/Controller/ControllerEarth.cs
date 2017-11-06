using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEarth : ControllerDefault
{
    bool uninitialized = true;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        if (uninitialized)
        {
            RunForce *= rigidbody.mass * -Physics2D.gravity.y;
            AirialForce *= rigidbody.mass;
            uninitialized = false;
        }

        ResetVelocity();
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        ResetVelocity();
    }

    protected override void Jump() { }

    void ResetVelocity()
    {
        var velocity = rigidbody.velocity;
        velocity.y = 0;
        rigidbody.velocity = velocity;
    }
}
