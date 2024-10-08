using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GafanhotoAttacking : StateMachineBehaviour
{
    private Transform target;
    private Rigidbody2D rb;
    private Gato gato;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
        this.rb = animator.GetComponent<Rigidbody2D>();
        gato = animator.GetComponent<Gato>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(target.position.x < this.gato.transform.position.x && !gato.isjumping){
            rb.AddForce(new Vector2(-0.3f, 3f), ForceMode2D.Impulse);
        }else if(target.position.x > this.gato.transform.position.x && !gato.isjumping){
            rb.AddForce(new Vector2(0.3f, 3f), ForceMode2D.Impulse);
        }else if(target.position.x == this.gato.transform.position.x){
            rb.AddForce(new Vector2(0f, -8f), ForceMode2D.Impulse);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
