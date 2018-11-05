using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeManager : MonoBehaviour {

    public GameObject door;
    public GameObject buttonScreen;
    public GameObject solutionScreen;
    public GameObject[] buttonPositions;
    public Material[] textures;
    

    bool problemSolved = false;
    public bool hasTheRightPerception = true;


    private GameObject[] instanciatedButtons;
    private GameObject instanciatedScreen;

    void Start () {
        int randSolution = (int)Random.Range(0, textures.Length - 1);   // On choisit la forme solution au hasard
        int randButton = (int)Random.Range(0, 2);                       // On choisit le boutton à qui attribuer solution
        instanciatedButtons = new GameObject[3];


        SetTextureOnTV(solutionScreen, textures[randSolution]);

		for(int i =0; i<3; i++)
        {
            instanciatedButtons[i] = Instantiate(buttonScreen);
            instanciatedButtons[i].transform.position = buttonPositions[i].transform.position;
            instanciatedButtons[i].GetComponent<ButtonEnigme>().enigmeManager = this;
            if (i == randButton)
            {
                SetTextureOnTV(instanciatedButtons[i], textures[randSolution]);
                instanciatedButtons[i].GetComponent<ButtonEnigme>().IsSolution = true;
            }                
            else
            {
                int randText = (int)Random.Range(0, textures.Length - 1);
                if(randText == randSolution)
                    randText = (randText + 1) % textures.Length;
                SetTextureOnTV(instanciatedButtons[i], textures[randText]);
                instanciatedButtons[i].GetComponent<ButtonEnigme>().IsSolution = false;
            }
        }
	}


    void SetTextureOnTV(GameObject obj, Material text)
    {
        MeshRenderer[] renderers = obj.GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer renderer in renderers)
        {
            if (renderer.gameObject.name == "TV")
            {
                Material[] mats = renderer.materials;
                mats[1] = text;
                renderer.materials = mats;
            }
                
        }
    }


    /**
     * Appelée par le bouton détenant la bonne réponse à l'énigme
     * Ouvre la porte si le joueur à débloqué la bonne perception
    **/
    public void SolveEnigme()
    {
        if (hasTheRightPerception)
        {
            if (!problemSolved)
            {
                problemSolved = true;
                Debug.Log("door");
                door.GetComponent<Door>().OpenDoor();
            }           
        }
        else
            ResetEnigme();
    }

    /**
     * Appelée par les boutons détenant les mauvaises réponses à l'énigme ou si le joueur n'a pas la bonne perception
     * Regénère trois nouvelles solutions
     **/
    public void ResetEnigme()
    {
    }
}
