using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// ---------------------------------------------
/// ---------SCR CONFIG AUDIO--------------------
/// Gestió de la configuració de l'àudio
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 07-03-19
/// ---------------------------------------------
/// </summary>

public class ScrConfigAudio : MonoBehaviour {

    //Declaració del VOLUM
    public AudioMixer generalAud;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetMasterVol(float volAdj_Gen) //Ajusta el SO GENERAL
    {
        generalAud.SetFloat("masterVol", volAdj_Gen);
    }

    public void SetMusVol(float volAdj_Mus) //Ajusta el SO MÚSICA
    {
        generalAud.SetFloat("musVol", volAdj_Mus);
    }

    public void SetSFXVol(float volAdj_So) //Ajusta el SO EFECTES
    {
        generalAud.SetFloat("sfxVol", volAdj_So);
    }

}
