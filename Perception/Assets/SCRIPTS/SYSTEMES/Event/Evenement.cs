using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Evenement : MonoBehaviour
{



    public virtual void activation()
    {
        gameObject.SetActive(true);
    }


    public virtual void desactivation()
    {
        gameObject.SetActive(false);
    }

    public virtual bool evenementIsEnCours()
    {
        return false;
    }
}