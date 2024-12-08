using ControlPanel.Script;
using UnityEditor;
using UnityEngine;

namespace ControlPanel.Editor.Script
{
    // [CustomEditor(typeof(ControlPanelMount), false)]
    public class ControlPanelMountInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            serializedObject.Update();

            EditorGUILayout.Space();

            if (GUILayout.Button("Reset control panel position to this mount"))
            {
                var controlPanelMount = target as ControlPanelMount;

                if (controlPanelMount != null)
                    controlPanelMount.RespawnAndRemountControlPanel();
            }

            GUILayout.Label("Made by nullshii with ♥", EditorStyles.boldLabel);

            serializedObject.ApplyModifiedProperties();
        }
    }
}