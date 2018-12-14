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

    public AudioClip sonCorrect;
    public AudioClip sonIncorrect;
    private AudioSource audioSource;
    // Use this for initialization
    public bool correctCombinaison;
    public bool finAllEnigme;

    void Start () {
        enigme[numEnigmeActuel].setisEncours(false);
        finAllEnigme = false;
        correctCombinaison = false;
        this.audioSource = GetComponent<AudioSource>();
        bouttonAppuyer = new List<int>();
        timeCombinaisonCooldown = 4;
        time = 0.0f;
        numEnigmeActuel = 0;
        if(enigme.Count>0)
        {
            solvableActuel = enigme[0].solvable;

        }
        

    }

    void Update()
    {
        Debug.Log(gameObject.name + "/" + getEnigmeActuel().name +"/"+ getEnigmeActuel().getisEncours());
        if (bouttonAppuyer.Count>0)
        {
            
            if (time+timeCombinaisonCooldown < Time.time  || bouttonAppuyer.Count==buttonEnigmes.Count)
            {
                if (!correctCombinaison)
                {
                    EnigmeEchec();
                }
                else
                {
                    correctCombinaison = false;
                }
                
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


    public void TestOneButton(int numero)
    {


        if (solvableActuel)
        {
            if (enigme[numEnigmeActuel].boutonCorrect == numero)
            {
                EnigmeReussi();

            }
            else
            {
                EnigmeEchec();
            }
        }
        else
        {
            EnigmeNonSolvable();
        }

    }

    public void TestCombinaison()
    {
        ScriptableBoutonEnigmes enigmeActuel = getEnigmeActuel();

        bool combinaisonEchec = false;

        if (enigmeActuel.listeCombinaison.Count == bouttonAppuyer.Count)
        {
            for (int i = 0; i < bouttonAppuyer.Count; i++)
            {
                if (enigmeActuel.listeCombinaison[i] != bouttonAppuyer[i])
                {
                    combinaisonEchec = true;
                }

            }
        }
        else
        {
            correctCombinaison = false;
            combinaisonEchec = true;
        }

        if (!combinaisonEchec)
        {

            correctCombinaison = true;
            EnigmeReussi();
        }
      
    }



    public void addCombinaison(int numero)
    {
        if (solvableActuel)
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
                TestCombinaison();
            }
        }
        else
        {
            EnigmeNonSolvable();
        }
        
        
    }



    public void EnigmeReussi()
    {
        ScriptableBoutonEnigmes butonOld = getEnigmeActuel();
        prochaineEnigme();
        LaunchEventReponse(butonOld.bonnes);
        this.audioSource.PlayOneShot(sonCorrect);
        
    }

    public void EnigmeEchec()
    {
        LaunchEventReponse(enigme[numEnigmeActuel].mauvaises);
        this.audioSource.PlayOneShot(sonIncorrect);
    }

    public void EnigmeNonSolvable()
    {
        this.audioSource.PlayOneShot(sonIncorrect);
        LaunchEventReponse(enigme[numEnigmeActuel].nonSolvable);
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
            enigme[numEnigmeActuel].setisEncours(false);
        }
        else
        {
            finAllEnigme = true;
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


    private Button findButton(int numero)
    {
        foreach (ButtonEnigme be in buttonEnigmes)
        {
            if (be.indice == numero)
            {
                return be.button.GetComponent<Button>();
            }
        }
        return null;
    }


}

public enum TypeEnigmeButton
{
    Groupe,
    Combinaison,

}
