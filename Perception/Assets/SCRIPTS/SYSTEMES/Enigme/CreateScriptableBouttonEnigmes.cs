using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

public class CreateScriptableBouttonGroupeEnigmes : MonoBehaviour {

    [MenuItem("Assets/Create/Enigmes/Boutton Groupe Enigme")]
    public static ScriptableBoutonGroupeEnigmes Create()
    {
        ScriptableBoutonGroupeEnigmes asset = ScriptableObject.CreateInstance<ScriptableBoutonGroupeEnigmes>();

        AssetDatabase.CreateAsset(asset, "Assets/DONNES/ENIGMES/GROUPE_BOUTTON/enigme.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}
#endif