using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableBoutonEnigmes : ScriptableObject {

    public TypeEnigmeButton typeEnigme;

    public string bonnes;
    public string mauvaises;
    public bool solvable;



    [HideInInspector]
    public List<int> listeCombinaison;
    [HideInInspector]
    public int boutonCorrect;

}
