using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BehaviourAIWarmup : AIBehaviour
{
    private bool warmedUp = false;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (warmedUp)
        {
            controller.FinishBehaviour();
            return;
        }   

        base.OnStateUpdate(animator, stateInfo, layerIndex);
        warmedUp = true;
    }
}
