using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StarterAssets;

public class BehaviourWander : AIBehaviour
{
    public float WaitTime = 1f;
    public float Radius = 5f;

    private float deltaTime = 0f;
    private Vector3 destination;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        Vector3 direction = Random.insideUnitSphere * Radius;
        direction += pawn.transform.position;
        NavMesh.SamplePosition(direction, out NavMeshHit hit, Radius, 1);

        destination = hit.position;
        pawn.Agent.SetDestination(destination);
        pawn.Agent.speed = pawn.GetComponent<ThirdPersonController>().MoveSpeed;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (pawn.transform.position == destination)
        {
            deltaTime += Time.deltaTime;

            if (deltaTime >= WaitTime)
            {
                controller.FinishBehaviour();
            }
        }
    }
}
