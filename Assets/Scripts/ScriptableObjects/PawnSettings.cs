using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pawn Settings", menuName = "Settings Assets/Pawn Settings")]
public class PawnSettings : ScriptableObject
{
    private static PawnSettings instance;
    public static PawnSettings Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PawnSettings>();
            }
            else
            {
                Debug.LogWarning("Multiple PawnSettings assets found!");
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }

    public GameObject DefaultPawnAIPrefab;
}
