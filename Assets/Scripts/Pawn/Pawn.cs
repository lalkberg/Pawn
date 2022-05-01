using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

[RequireComponent(typeof(NavMeshAgent))]
public class Pawn : MonoBehaviour
{
    public bool PossessedByPlayer => PlayerController.Instance.PossessedPawn == this;
    public NavMeshAgent Agent
    {
        get => agent;
        private set => agent = value;
    }

    public GameObject AIControllerPrefab;
    private AIController aiController;
    public AIController AIController => aiController;

    public static List<Pawn> allUnpossessedPawns => FindObjectsOfType<Pawn>().Where(x => x.PossessedByPlayer == false).ToList();

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject go = Instantiate(AIControllerPrefab);

        if (go.TryGetComponent<AIController>(out aiController))
        {
            aiController = go.GetComponent<AIController>();

            aiController.Possess(this);
        }
        else
        {
            Debug.LogWarning($"Pawn {gameObject.name}'s AI Controller prefab is missing the AI Controller component.");
        }
    }

    public PawnController GetController()
    {
        foreach (PawnController pc in FindObjectsOfType<PawnController>())
        {
            if (pc.PossessedPawn == this) return pc;
        }
        return null;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
