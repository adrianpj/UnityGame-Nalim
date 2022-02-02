using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; //per a trucar qualssevol FUNCIÓ dins del Plugin

/// <summary>
/// ---------------------------------------------
/// ---------SCR FUNGUS LOCALIZATION-------------
/// Gestió del control d'idioma a FUNGUS
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 16-02-19
/// ---------------------------------------------
/// </summary>

public class ScrFungus_localization : MonoBehaviour {

    //Declaració de l'IDIOMA del FUNGUS
    public Flowchart Fungus_localization;

    // Use this for initialization
    void Start () {

        Fungus_localization.SetIntegerVariable("idLang", ScrCtrlGame.numLanguage);

    }
}
