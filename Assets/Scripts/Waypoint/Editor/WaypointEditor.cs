
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
    Waypoint waypointTarget => target as Waypoint;

    private void OnSceneGUI()
    {
        Handles.color = Color.red;
        if (waypointTarget.Points == null)
        {
            return;
        }

        for (int i = 0; i < waypointTarget.Points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();
            Vector3 actualPoint = waypointTarget.actualPosition + waypointTarget.Points[i];
            var fmh_22_68_638088814347127743 = Quaternion.identity; Vector3 newPoint = Handles.FreeMoveHandle(actualPoint, 0.7f, new Vector3(0.3f, 0.3f, 0.3f), Handles.SphereHandleCap);
            GUIStyle text = new GUIStyle();
            text.fontStyle = FontStyle.Bold;
            text.fontSize = 16;
            text.normal.textColor = Color.black;
            Vector3 alineamiento = Vector3.down * 0.3f + Vector3.right * 0.3f;
            Handles.Label(waypointTarget.actualPosition + waypointTarget.Points[i] + alineamiento, $"{i + 1}");
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Free move handle");
                waypointTarget.Points[i] = newPoint - waypointTarget.actualPosition;
            }
        }
    }
}
