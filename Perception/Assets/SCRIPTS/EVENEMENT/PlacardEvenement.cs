using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacardEvenement : Evenement {

    
    public void setActivable(bool active)
    {
        GetComponent<Placard>().activable = active;
    }


}
