using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerFire : ControllerDefault
{
    [SerializeField]
    float LowSpeedThreashold = 1;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        Dash();
    }

    override protected void Move()
    {
        if (Mathf.Abs(rigidbody.velocity.x) < LowSpeedThreashold)
        {
            kannaOperation.Direction *= -1;
        }
        Dash();
    }

    void Dash()
    {
        var velocity = rigidbody.velocity;
        velocity.x = kannaOperation.Direction * RunForce;
        rigidbody.velocity = velocity;
    }
}
