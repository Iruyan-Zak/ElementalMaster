using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDefault : StateMachineBehaviour
{
    [SerializeField]
    protected float RunForce = 10;
    [SerializeField]
    protected float AirialForce = 2;
    [SerializeField]
    protected float JumpForce = 5;
    [SerializeField]
    protected float MaxSpeed = 2.5f;

    protected Transform transform;
    protected Rigidbody2D rigidbody;
    protected KannaOperation kannaOperation;

    bool uninitialized = true;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (uninitialized)
        {
            transform = animator.transform;
            rigidbody = transform.GetComponent<Rigidbody2D>();
            kannaOperation = transform.GetComponent<KannaOperation>();

            uninitialized = false;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Move();
        Jump();
    }

    protected virtual void Move()
    {
        var dx = Input.GetAxis("Horizontal");

        if (dx != 0 && kannaOperation.IsGrounded)
        {
            kannaOperation.Direction = dx;
        }

        if (rigidbody.velocity.x * Mathf.Sign(dx) < MaxSpeed)
        {
            rigidbody.AddForce((kannaOperation.IsGrounded ? RunForce : AirialForce) * new Vector2(dx, 0));
        }
    }

    protected virtual void Jump()
    {
        if (Input.GetButtonDown("Jump") && kannaOperation.IsGrounded)
        {
            rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
