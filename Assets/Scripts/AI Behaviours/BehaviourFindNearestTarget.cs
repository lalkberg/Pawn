using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BehaviourFindNearestTarget : AIBehaviour
{
    public float InRadius = 5f;
    public Vector3 Center = Vector3.zero;
    public LayerMask LayerMask;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        Collider[] colliders = Physics.OverlapSphere(pawn.transform.position + Center, InRadius);

        if (colliders.Length == 0) return;

        List<Pawn> potentialTargets = new List<Pawn>();

        for (int i = 0; i <= colliders.Length - 1; i++)
        {
            if (colliders[i].TryGetComponent(out Pawn other))
            {
                if (other == pawn) continue;

                potentialTargets.Add(other);
            }
        }

        if(potentialTargets.Count == 0) return;

        Pawn nearest = null;
        float bestDistance = float.MaxValue;

        foreach(Pawn other in potentialTargets)
        {
            float distance = (other.transform.position - pawn.transform.position).magnitude;

            if(distance < bestDistance)
            {
                nearest = other;
            }
        }

        controller.SetTarget(nearest);
        controller.FinishBehaviour();
    }
}
