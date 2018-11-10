using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupeBouttonEnigme : MonoBehaviour {

    private int enigmeActuel;
    public List<ScriptableBoutonGroupeEnigmes> enigme;
    [HideInInspector]
    public bool solvableActuel;


	// Use this for initialization
	void Start () {
        enigmeActuel = 0;
        if(enigme.Count>0)
        {
            solvableActuel = enigme[0].solvable;

        }
        

    }


    public void TestOneButton(int numero)
    {
        Debug.Log(enigme.Count);
        if (solvableActuel && enigme[enigmeActuel].boutonCorrect == numero)
        {
            BouttonCorrect(enigme[enigmeActuel].bonnes);
            prochaineEnigme();
        }
        else
        {
            BouttonIncorrect(enigme[enigmeActuel].mauvaises);
        }

    }

    public void BouttonCorrect(string bouton)
    {
        foreach (EventManager eM in GetComponents<EventManager>())
        {
            if (eM.nomEvent.Equals(bouton))
            {
                eM.activation();
            }
        }
    }

    public void BouttonIncorrect(string bouton)
    {
        foreach (EventManager eM in GetComponents<EventManager>())
        {
            if (eM.nomEvent.Equals(bouton))
            {
                eM.activation();
            }
        }
    }

    private void prochaineEnigme()
    {
        if (enigme.Count> enigmeActuel+1)
        {
            enigmeActuel++;
            solvableActuel = enigme[enigmeActuel].solvable;
        }

    }



}
