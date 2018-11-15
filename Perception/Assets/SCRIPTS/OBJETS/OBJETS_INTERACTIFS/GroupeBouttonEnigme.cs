using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupeBouttonEnigme : MonoBehaviour {

    private int numEnigmeActuel;
    public List<ScriptableBoutonEnigmes> enigme;
    [HideInInspector]
    public bool solvableActuel;

    public List<int> bouttonAppuyer;

    private float time;
    private int timeCombinaisonCooldown;

	// Use this for initialization
	void Start () {
        bouttonAppuyer = new List<int>();
        timeCombinaisonCooldown = 5;
        time = 0.0f;
        numEnigmeActuel = 0;
        if(enigme.Count>0)
        {
            solvableActuel = enigme[0].solvable;

        }
        

    }

    private void Update()
    {
        if (bouttonAppuyer.Count>0)
        {
            
            if (time+timeCombinaisonCooldown < Time.time)
            {
                bouttonAppuyer = new List<int>();
                time = 0.0f;
            }
            
        }
    }

    public void TestCombinaison()
    {
        ScriptableBoutonEnigmes enigmeActuel = getEnigmeActuel();

        bool combinaisonEchec = false;
        if (solvableActuel && enigmeActuel.listeCombinaison.Count == bouttonAppuyer.Count)
        {
            for (int i=0;i< bouttonAppuyer.Count;i++)
            {
                if (enigmeActuel.listeCombinaison[i] != bouttonAppuyer[i])
                {
                    combinaisonEchec = true;
                }
                
            }
        }
        else
        {
            combinaisonEchec = true;
        }

        if (!combinaisonEchec)
        {
            BouttonCorrect(enigmeActuel.bonnes);
            prochaineEnigme();
        }
    }


    public void TestOneButton(int numero)
    {
        if (solvableActuel && enigme[numEnigmeActuel].boutonCorrect == numero)
        {
            BouttonCorrect(enigme[numEnigmeActuel].bonnes);
            prochaineEnigme();
        }
        else
        {
            BouttonIncorrect(enigme[numEnigmeActuel].mauvaises);
        }

    }

    public void addCombinaison(int numero)
    {
        if (!(bouttonAppuyer.Contains(numero)))
        {
            bouttonAppuyer.Add(numero);
            time = Time.time;
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
        if (enigme.Count> numEnigmeActuel+1)
        {
            numEnigmeActuel++;
            solvableActuel = enigme[numEnigmeActuel].solvable;
        }

    }

    public ScriptableBoutonEnigmes getEnigmeActuel()
    {
        return enigme[numEnigmeActuel];
    }

    public TypeEnigmeButton getTypeEnigmeActuel()
    {
        return getEnigmeActuel().typeEnigme;
    }



}

public enum TypeEnigmeButton
{
    Groupe,
    Combinaison,

}
