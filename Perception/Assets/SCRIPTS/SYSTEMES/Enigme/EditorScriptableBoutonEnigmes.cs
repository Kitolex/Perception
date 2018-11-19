using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(ScriptableBoutonEnigmes))]
public class EditorScriptableBoutonEnigmes : Editor
{

    public override void OnInspectorGUI()
    {


        base.OnInspectorGUI();
        ScriptableBoutonEnigmes enigme = (ScriptableBoutonEnigmes)target;
        //myPorte.isDecorative = EditorGUILayout.Toggle ("Porte décorative :",myPorte.isDecorative);
        if (enigme.typeEnigme.Equals(TypeEnigmeButton.Groupe))
        {
            enigme.boutonCorrect = EditorGUILayout.IntField("Boutton Correct : ", enigme.boutonCorrect);
        }
        else if  (enigme.typeEnigme.Equals(TypeEnigmeButton.Combinaison))
        {
            var list = enigme.listeCombinaison;
            int newCount = Mathf.Max(0, EditorGUILayout.IntField("size", list.Count));
            while (newCount < list.Count)
                list.RemoveAt(list.Count - 1);
            while (newCount > list.Count)
                list.Add(0);

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = EditorGUILayout.IntField(list[i]);
            }
        }
        
    }


}
#endif