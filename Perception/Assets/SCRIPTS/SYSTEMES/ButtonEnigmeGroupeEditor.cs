using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(GroupeBouttonEnigme))]
public class ButtonEnigmeGroupeEditor : Editor
{
    private ReorderableList list;


    private void OnEnable()
    {
        list = new ReorderableList(serializedObject,
            serializedObject.FindProperty("buttonEnigmes"),
            true, true, true, true);
        list.drawElementCallback =
            (Rect rect, int index, bool isActive, bool isFocused) => {
                var element = list.serializedProperty.GetArrayElementAtIndex(index);
                rect.y += 2;
                EditorGUI.PropertyField(
                    new Rect(rect.x, rect.y, rect.width / 2, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("button"), GUIContent.none);
                EditorGUI.PropertyField(
                    new Rect(rect.x + rect.width / 2, rect.y, rect.width / 2, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("indice"), GUIContent.none);
            };
        list.drawHeaderCallback = (Rect rect) => {
            EditorGUI.LabelField(rect, "Liste Boutton Enigme");
        };


    }

    public override void OnInspectorGUI()
    {


        base.OnInspectorGUI();
        GroupeBouttonEnigme myPorte = (GroupeBouttonEnigme)target;
        //myPorte.isDecorative = EditorGUILayout.Toggle ("Porte décorative :",myPorte.isDecorative);
            serializedObject.Update();
            list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();



    }
}
#endif