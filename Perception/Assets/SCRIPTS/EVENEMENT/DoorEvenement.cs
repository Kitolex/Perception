using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvenement : Evenement {

    override
    public void activation()
    {
        GetComponent<Door>().OpenDoor();
    }

    override
    public void desactivation()
    {
        GetComponent<Door>().CloseDoor();
    }
}
