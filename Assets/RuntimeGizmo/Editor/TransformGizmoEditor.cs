using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RuntimeGizmos {

    [CustomEditor(typeof(TransformGizmo))]
    public class TransformGizmoEditor : Editor {
        public override void OnInspectorGUI() {
            TransformGizmo tfGizmo = target as TransformGizmo;

            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script:", MonoScript.FromMonoBehaviour((TransformGizmo) target), typeof(TransformGizmo), false);
            GUI.enabled = true;

            tfGizmo.space = (TransformSpace) EditorGUILayout.EnumPopup("Space", tfGizmo.space);

            if (tfGizmo.space == TransformSpace.ObjectRelative) {
                tfGizmo.objectRelativeTransform = (Transform) EditorGUILayout.ObjectField("Object Relative Transform", tfGizmo.objectRelativeTransform, typeof(Transform), true);
            }

            if (GUI.changed)
                EditorUtility.SetDirty(tfGizmo);

            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject, new string[] { "m_Script" });
            serializedObject.ApplyModifiedProperties();
        }

    }

}

