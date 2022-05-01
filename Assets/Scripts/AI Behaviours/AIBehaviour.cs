using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : StateMachineBehaviour
{
    protected Pawn pawn;
    protected Pawn target;
    protected AIController controller;

    protected float tickDuration => Time.deltaTime * 3;
    protected float currentTick = 0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (controller == null)
        {
            controller = animator.GetComponent<AIController>();
        }

        if (pawn == null)
        {
            pawn = controller.PossessedPawn;
        }

        controller.StartBehaviour();
    }

    protected void SetTarget(Pawn newTarget, bool setControllerTarget = false)
    {
        target = newTarget;

        if (setControllerTarget) controller.SetTarget(newTarget);
    }

    protected void SetTargetFromComponent()
    {
        target = controller.Target;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentTick += Time.deltaTime;

        if(currentTick >= tickDuration)
        {
            currentTick = 0;
        }
        else return; 
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
