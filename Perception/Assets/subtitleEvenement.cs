using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subtitleEvenement : Evenement {

    public void LancerSousTitre(string key)
    {
        SubtitleManager.Instance.startTextsSequence(key);
    }



}
