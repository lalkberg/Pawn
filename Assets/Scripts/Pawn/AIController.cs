using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AIController : PawnController
{
    public Animator StateMachine { get; private set; }

    public bool Success { get; private set; }
    public Pawn Target { get; private set; }

    private int AnimSuccessParameter => Animator.StringToHash("Success");
    private int AnimHasTargetParameter => Animator.StringToHash("Has Target");
    private int AnimResetTriggerParameter => Animator.StringToHash("Reset");

    public void StartBehaviour()
    {
        Success = false;
    }

    public void FinishBehaviour()
    {
        Success = true;
    }

    public void SetTarget(Pawn target)
    {
        Target = target;
    }

    public void RemoveTarget()
    {
        Target = null;
    }

    public void ResetStateMachine()
    {
        StateMachine.SetTrigger(AnimResetTriggerParameter);

        StateMachine.enabled = false;
    }

    public override void Possess(Pawn pawn)
    {
        base.Possess(pawn);

        if (StateMachine == null) return;
        
        StateMachine.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        StateMachine = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PossessedPawn == null)
        {
            StateMachine.enabled = false;
            return;
        }
        else if (StateMachine.enabled == false)
        {
            StateMachine.enabled = true;
        }

        if (StateMachine.GetBool(AnimSuccessParameter) != Success)
        {
            StateMachine.SetBool(AnimSuccessParameter, Success);
        }
    }
}
