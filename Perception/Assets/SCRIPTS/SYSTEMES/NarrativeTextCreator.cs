using UnityEngine;
using System.Collections;
using UnityEditor;

public class NarrativeTextCreator {
    [MenuItem("Assets/Create/Subtitles", false, 0)]
    public static void CreateMyAsset()
    {
        NarrativeText asset = ScriptableObject.CreateInstance<NarrativeText>();

        AssetDatabase.CreateAsset(asset, "Assets/DONNES/SUBTITLES/NewSubtitles.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}