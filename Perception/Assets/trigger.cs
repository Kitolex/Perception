using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {

    public string sousTitre;

    private void OnTriggerEnter(Collider other)
    {
        SubtitleManager.Instance.startTextsSequence(sousTitre);
    }

}
