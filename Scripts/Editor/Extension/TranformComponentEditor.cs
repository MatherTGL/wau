using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Transform), true)]
public sealed class TranformComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var transform = target as Transform;
        if (!transform) return;

        EditorGUIUtility.labelWidth = 15f;

        Vector3 position;
        Vector3 rotation;
        Vector3 scale;

        bool isResetValid;
       

        EditorGUILayout.BeginHorizontal();
        {
            isResetValid = IsResetVectorValid(transform.localPosition, Vector3.zero);
            if (DrawButton("R/P", "Reset Position", isResetValid, 20f, 20f))
            {
                Undo.RecordObject(transform, "Reset Position");
                transform.localPosition = Vector3.zero;
            }
            position = DrawVector3(transform.localPosition);
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        {
            isResetValid = IsResetVectorValid(transform.localEulerAngles, Vector3.zero);
            if (DrawButton("R/R", "Reset Rotation", isResetValid, 20f, 20f))
            {
                Undo.RecordObject(transform, "Reset Rotation");
                transform.localEulerAngles = Vector3.zero;
            }
            rotation = DrawVector3(transform.localEulerAngles);
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        {
            isResetValid = IsResetVectorValid(transform.localScale, Vector3.one);
            if (DrawButton("R/S", "Reset Scale", isResetValid, 20f, 20f))
            {
                Undo.RecordObject(transform, "Reset Scale");
                transform.localScale = Vector3.one;
            }
            scale = DrawVector3(transform.localScale);
        }
        EditorGUILayout.EndHorizontal();

        if (GUI.changed)
        {
            Undo.RecordObject(transform, "Transform Change");
            transform.localPosition = ValidateVector(position);
            transform.localEulerAngles = ValidateVector(rotation);
            transform.localScale = ValidateVector(scale);
        }
    }

    private static bool DrawButton(string title, string tooltip, bool enabled, float width, float height)
    {
        if (enabled)
        {
            return GUILayout.Button(new GUIContent(title, tooltip), GUILayout.MinWidth(width), GUILayout.MinHeight(height));
        }

        var color = GUI.color;
        GUI.color = new Color(1f, 1f, 1f, 0.25f);
        GUILayout.Button(new GUIContent(title, tooltip), GUILayout.MinWidth(width));
        GUI.color = color;

        return false;
    }

    private static Vector3 DrawVector3(Vector3 value)
    {
        var option = GUILayout.MinWidth(30f);

        value.x = EditorGUILayout.FloatField("X", value.x, option);
        value.y = EditorGUILayout.FloatField("Y", value.y, option);
        value.z = EditorGUILayout.FloatField("Z", value.z, option);

        return value;
    }

    private static bool IsResetVectorValid(Vector3 vector, Vector3 target)
    {
        return (vector.x != target.x || vector.y != target.y || vector.z != target.z);
    }

    private static Vector3 ValidateVector(Vector3 vector)
    {
        vector.x = float.IsNaN(vector.x) ? 0f : vector.x;
        vector.y = float.IsNaN(vector.y) ? 0f : vector.y;
        vector.z = float.IsNaN(vector.z) ? 0f : vector.z;
        return vector;
    }
}
