using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using StarterAssets;
using UnityEngine.AI;

[CustomEditor(typeof(Pawn))]
public class PawnEditor : Editor
{
    private const string buttonName = "Possess";
    private const string buttonTooltip = "Forces the PlayerController instance to possess this Pawn. If pressed during Edit Mode, instead selects this Pawn as the default one for the scene.";
    public override void OnInspectorGUI()
    {
        GUIContent buttonContent = new GUIContent (buttonName, buttonTooltip);

        if (GUILayout.Button(buttonContent))
        {
            Pawn pawn = target as Pawn;
            if (Application.isPlaying)
            {                
                PlayerController.Instance.Possess(pawn);
            }
            else
            {
                Debug.Log(pawn.gameObject.name + " chosen as default pawn.");
                PlayerController.Instance.InitialPawn = pawn;
            }
        }

        base.OnInspectorGUI();
    }

    [MenuItem("GameObject/Pawn")]
    private static void CreatePawn()
    {
        GameObject pawnObject = new GameObject("Pawn", typeof(Pawn), typeof(ThirdPersonController));

        string aiPrefabPath = AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("BasicAIPrefab")[0]);
        Debug.Log(aiPrefabPath);
        pawnObject.GetComponent<Pawn>().AIControllerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(aiPrefabPath);

        pawnObject.GetComponent<CharacterController>().center = Vector3.up;

        GameObject cameraPoint = new GameObject("Camera Target");
        cameraPoint.transform.localPosition = Vector3.up;
        cameraPoint.transform.localEulerAngles = Vector3.zero;
        cameraPoint.transform.SetParent(pawnObject.transform);

        pawnObject.GetComponent<ThirdPersonController>().CinemachineCameraTarget = cameraPoint;

        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule.transform.localPosition = Vector3.up;
        capsule.transform.localEulerAngles = Vector3.zero;
        capsule.transform.SetParent(pawnObject.transform);
        DestroyImmediate(capsule.GetComponent<Collider>());
    }
}
