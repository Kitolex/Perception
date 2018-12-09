using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecteurEvenement : Evenement {

    public Material m;
    public float intensite=2;
    public List<GameObject> spot;


    public void flash()
    {
        Debug.Log("flash");
        SoundManager.Instance.PlayOneTimeNotSpacializedSound(SoundManager.Instance.projecteurFlash);
        foreach (GameObject go in spot)
        {
            Material m = go.GetComponent<Renderer>().material;
            Debug.Log(m.name);
            m.EnableKeyword("_EMISSION");
            VisionStateMachine.Instance.ChangeState(VisionStates.FlashVision);
        }
    }
    override
    public bool evenementIsEnCours()
    {
        if (intensite<1.1)
        {
            return false;
        }

        return true;
    }




}
