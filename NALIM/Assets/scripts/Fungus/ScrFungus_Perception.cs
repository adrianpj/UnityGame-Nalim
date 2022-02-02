using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

/// <summary>
/// ---------------------------------------------
/// ---------SCR FUNGUS PERCEPTION---------------
/// Gestió del control del PLAYER dins de FUNGUS
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 16-02-19
/// ---------------------------------------------
/// </summary>

public class ScrFungus_Perception : MonoBehaviour {

    public Flowchart Fungus_Scene;

    void Update()
    {
        Fungus_Scene.SetIntegerVariable("valPerception", ScrCtrlGame.pointStatistic[2]);
    }
}
