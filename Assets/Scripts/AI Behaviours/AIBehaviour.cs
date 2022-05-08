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

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentTick += Time.deltaTime;

        if(currentTick >= tickDuration)
        {
            currentTick = 0;
        }
        else return; 
    }
}
