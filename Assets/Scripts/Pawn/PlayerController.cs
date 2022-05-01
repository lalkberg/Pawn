using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class PlayerController : PawnController
{
    private static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerController>();
                
                if (instance == null)
                {
                    GameObject go = new GameObject("Pawn Controller");
                    instance = go.AddComponent<PlayerController>();
                }
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }

    public Pawn InitialPawn;

    public CinemachineVirtualCamera PlayerVirtualCamera;

    public override void Possess(Pawn pawn)
    {
        if (Instance.PossessedPawn != null)
        {
            Instance.PossessedPawn.AIController.Possess(PossessedPawn);
            pawn.AIController.ResetStateMachine();
            Instance.PossessedPawn.Agent.enabled = true;
        }

        pawn.GetController().Possess(null);
        pawn.Agent.enabled = false;

        Instance.PlayerVirtualCamera.Follow = pawn.GetComponent<ThirdPersonController>().CinemachineCameraTarget.transform;

        base.Possess(pawn, Instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance.Possess(InitialPawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
