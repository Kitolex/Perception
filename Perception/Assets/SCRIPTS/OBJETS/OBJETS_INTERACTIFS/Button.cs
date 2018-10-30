using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : ObjetInteractifs
{


    private EventManager eventManager;


    // Use this for initialization
    void Start()
    {
        eventManager = GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Activation()
    {
        
        Debug.Log("BOUTTON ACTIONNER");
        eventManager.activation();
        //TODO : activation boutton
    }


}
