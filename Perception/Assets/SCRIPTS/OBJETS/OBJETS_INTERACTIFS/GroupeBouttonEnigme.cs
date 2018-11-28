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
    [HideInInspector]
    public List<ButtonEnigme> buttonEnigmes = new List<ButtonEnigme>();

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
                endLightAllButton();
                bouttonAppuyer = new List<int>();
                time = 0.0f;
            }
            
        }
    }

    private void endLightAllButton()
    {
        foreach (ButtonEnigme be in buttonEnigmes)
        {
            be.button.GetComponent<Button>().DesactivateLight();
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
            LaunchEventReponse(enigmeActuel.bonnes);
            prochaineEnigme();
        }
    }


    public void TestOneButton(int numero)
    {
        if (solvableActuel && enigme[numEnigmeActuel].boutonCorrect == numero)
        {
            LaunchEventReponse(enigme[numEnigmeActuel].bonnes);
            prochaineEnigme();
        }
        else
        {
            LaunchEventReponse(enigme[numEnigmeActuel].mauvaises);
        }

    }

    public void addCombinaison(int numero)
    {
        if (!(bouttonAppuyer.Contains(numero)))
        {
            bouttonAppuyer.Add(numero);
            Button be = findButton(numero);
            if (be != null)
            {
                be.ActivateLight();
            }
            time = Time.time;
        }
        
    }

    private Button findButton(int numero)
    {
        foreach (ButtonEnigme be in buttonEnigmes)
        {
            if (be.indice==numero)
            {
                return be.button.GetComponent<Button>();
            }
        }
        return null;
    }

    public void LaunchEventReponse(string bouton)
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
