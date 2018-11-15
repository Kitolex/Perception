using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

public class CreateScriptableBoutonEnigmes : MonoBehaviour {


    [MenuItem("Assets/Create/Enigmes/Boutton Enigme")]
    public static ScriptableBoutonEnigmes ScriptableBoutonEnigmes()
    {
        ScriptableBoutonEnigmes asset = ScriptableObject.CreateInstance<ScriptableBoutonEnigmes>();

        AssetDatabase.CreateAsset(asset, "Assets/DONNES/ENIGMES/GROUPE_BOUTTON/enigme.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }

}
#endif