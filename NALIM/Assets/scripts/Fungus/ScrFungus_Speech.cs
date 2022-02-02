using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

/// <summary>
/// ---------------------------------------------
/// ---------SCR FUNGUS SPEECH-------------------
/// Gestió del control del PLAYER dins de FUNGUS
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 16-02-19
/// ---------------------------------------------
/// </summary>

public class ScrFungus_Speech : MonoBehaviour {

    public Flowchart Fungus_Scene;

    void Update()
    {

        //Actualitza el booleà ESTÀ PARLANT
        ScrCtrlFungus.in_Speech = Fungus_Scene.GetBooleanVariable("in_speech");
    }
}
