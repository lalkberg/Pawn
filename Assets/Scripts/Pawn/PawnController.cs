using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : MonoBehaviour
{
    public Pawn PossessedPawn { get; private set; }

    public virtual void Possess(Pawn pawn)
    {
        foreach(PawnController pc in FindObjectsOfType<PawnController>())
        {
            if (pc.PossessedPawn == this)
            {
                pc.PossessedPawn = null;
            }
        }

        PossessedPawn = pawn;
    }

    public virtual void Possess(Pawn pawn, PawnController controller)
    {
        foreach(PawnController pc in FindObjectsOfType<PawnController>())
        {
            if (pc.PossessedPawn == this)
            {
                pc.PossessedPawn = null;
            }
        }

        controller.PossessedPawn = pawn;
    }
}
