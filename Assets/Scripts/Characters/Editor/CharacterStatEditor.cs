using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(CharacterStats))]
public class CharacterStatEditor : Editor
{
    public CharacterStats statsTarget => target as CharacterStats;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Reset values"))
        {
            statsTarget.ResetValues();
        }
    }

}
