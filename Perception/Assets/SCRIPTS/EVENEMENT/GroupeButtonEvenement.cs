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
        gbe.TestOneButton(numero);
    }

    public void setSolvable(bool solvable)
    {
         gbe.solvableActuel = solvable;
    }
}
