using System;
using ControlPanel.Script;
using UnityEditor;
using UnityEngine;

namespace ControlPanel.Editor.Script
{    
    [CustomEditor(typeof(ControlPanelMount), false)]
    public class ControlPanelMountInspector : UnityEditor.Editor
    {
        private SerializedProperty _serializedControlPanel;

        private void OnEnable()
        {
            _serializedControlPanel = serializedObject.FindProperty("_controlPanel");
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            serializedObject.Update();

            EditorGUILayout.Space();

            if (GUILayout.Button("Auto detect control panel"))
            {
                var controlPanels = FindObjectsOfType<ControlPanel.Script.ControlPanel>();

                switch (controlPanels.Length)
                {
                    case 0:
                        Debug.LogWarning("Control panel not found.");
                        return;
                    case > 1:
                        Debug.LogWarning("Multiple control panels found in scene! Consider using 1 panel and many mount points.");
                        return;
                }

                ControlPanel.Script.ControlPanel controlPanel = controlPanels[0]; 
                _serializedControlPanel.objectReferenceValue = controlPanel;
            }
            
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