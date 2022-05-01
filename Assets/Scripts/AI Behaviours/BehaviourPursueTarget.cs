using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class BehaviourPursueTarget : AIBehaviour
{
    public float MaxPursuitDistance = 10f;
    public float StoppingDistance = 1.5f;
    public float SprintMaxDistance = 3f;
    private ThirdPersonController character;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        character = pawn.GetComponent<ThirdPersonController>();
        SetTargetFromComponent();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (target == null)
        {
            FinishPursuit();
            return;
        }

        float distance = Vector3.Distance(pawn.transform.position, target.transform.position);

        if (distance <= StoppingDistance || distance >= MaxPursuitDistance)
        {
            FinishPursuit();
            return;
        }

        if (distance > SprintMaxDistance)
        {
            pawn.Agent.speed = character.SprintSpeed;
        }
        else
        {
            pawn.Agent.speed = character.MoveSpeed;
        }

        pawn.Agent.SetDestination(target.transform.position);
    }

    private void FinishPursuit()
    {
        pawn.Agent.SetDestination(pawn.transform.position);
        controller.FinishBehaviour();
    }
}
