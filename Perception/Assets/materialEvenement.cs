using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialEvenement : Evenement {

    public Material m;

    public void enleverEmmisive()
    {
        m.DisableKeyword("_EMISSION");
    }
}
