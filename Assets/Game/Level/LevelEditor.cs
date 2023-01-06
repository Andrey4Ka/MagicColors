using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(Level))]
//public class LevelEditor : Editor
//{
//    Level targetScript;

//    void OnEnable()
//    {
//        targetScript = target as Level;
//    }

//    public override void OnInspectorGUI()
//    {
//        targetScript.Gradient = (Sprite)EditorGUILayout.ObjectField(targetScript.Gradient, typeof(Sprite), true);
//        targetScript.Width = EditorGUILayout.IntField(targetScript.Width);
//        targetScript.Height = EditorGUILayout.IntField(targetScript.Height);

//        if (targetScript.Interactables == null || targetScript.Interactables.GetLength(0) != targetScript.Width || targetScript.Interactables.GetLength(1) != targetScript.Height)
//        {
//            targetScript.Interactables = new bool[targetScript.Width, targetScript.Height];
//        }

//        EditorGUILayout.BeginHorizontal();
//        for (int y = 0; y < targetScript.Height; y++)
//        {
//            EditorGUILayout.BeginVertical();
//            for (int x = 0; x < targetScript.Width; x++)
//            {
//                targetScript.Interactables[x, y] = EditorGUILayout.Toggle(targetScript.Interactables[x, y]);
//            }
//            EditorGUILayout.EndVertical();

//        }
//        EditorGUILayout.EndHorizontal();
//    }
//}