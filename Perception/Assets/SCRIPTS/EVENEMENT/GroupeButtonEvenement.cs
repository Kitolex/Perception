using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupeButtonEvenement : Evenement {

    GroupeBouttonEnigme gbe;

    private void Awake()
    {
        gbe = GetComponent<GroupeBouttonEnigme>();
        
    }


    public void boutonAppuyer(int numero)
    {
        Debug.Log(gbe.getEnigmeActuel().getisEncours());
        if (gbe.getEnigmeActuel().getisEncours() && !gbe.finAllEnigme)
        {
            if (gbe.getTypeEnigmeActuel().Equals(TypeEnigmeButton.Groupe))
            {
                gbe.TestOneButton(numero);
            }
            else if (gbe.getTypeEnigmeActuel().Equals(TypeEnigmeButton.Combinaison))
            {
                gbe.addCombinaison(numero);
               // gbe.TestCombinaison();
            }
        }     
    }

    public void setActiveEnigmeActuel(bool etat)
    {
        gbe.getEnigmeActuel().setisEncours(etat);
    }

    public void setSolvable(bool solvable)
    {
         gbe.solvableActuel = solvable;
    }
}
