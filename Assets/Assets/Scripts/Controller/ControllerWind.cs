using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerWind : ControllerDefault
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        Fly();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        var velocity = rigidbody.velocity;
        velocity.y = 0;
        rigidbody.velocity = velocity;
    }

    protected override void Jump()
    {
        Fly();

        var dx = Input.GetAxis("Horizontal");
        if (Mathf.Abs(dx) != 0)
        {
            kannaOperation.Direction = dx;
        }
    }

    void Fly()
    {
        var velocity = rigidbody.velocity;
        velocity.y = JumpForce;
        rigidbody.velocity = velocity;
    }
}
