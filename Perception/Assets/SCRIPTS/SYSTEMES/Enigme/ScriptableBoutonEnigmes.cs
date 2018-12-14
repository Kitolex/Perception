using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableBoutonEnigmes : ScriptableObject {

    public TypeEnigmeButton typeEnigme;

    public string bonnes="correct";
    public string mauvaises= "mauvais";
    public bool solvable = true;



    [HideInInspector]
    public List<int> listeCombinaison;
    [HideInInspector]
    public int boutonCorrect;
    public string nonSolvable;

    private bool isEnCours;



    public void setisEncours(bool etat)
    {
        isEnCours = etat;
    }

    public bool getisEncours()
    {
        return isEnCours;
    }
}
