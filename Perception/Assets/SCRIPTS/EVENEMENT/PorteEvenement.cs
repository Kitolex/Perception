using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteEvenement : Evenement {

    override
    public void activation()
    {
        Debug.Log("Porte Activé");
    }
}
