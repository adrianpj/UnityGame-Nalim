using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ScrLevelUp : MonoBehaviour {

    /// <summary>
    /// ---------------------------------------------
    /// ---------SCR LEVEL UP------------------------
    /// Funció que actualitza al passar de nivell
    /// 
    /// Versió 0.1
    /// Carlos Serrano
    /// Data 05-04-19
    ///     0.1 primera versió
    /// ---------------------------------------------
    /// </summary>

    public Flowchart Fungus_Scene;

    void OnEnable()
    {
        ScrCtrlGame.Point_total = 999; // Incrementa el punt que pot arribar a posar a les habilitats

        //********Increment dels punts d'experiència i el nivell requerits***********
        ScrCtrlGame.Pers_level++; //Incrementa el nombre de nivell
        ScrCtrlGame.XP_Next = 10 * (ScrCtrlGame.Pers_level + 1); //Incrementa els punts requerits per al següent nivell

        //Actualitza les variables a les components del flowchart
        Fungus_Scene.SetIntegerVariable("valXPPlayer", ScrCtrlGame.XP_Point);
        Fungus_Scene.SetIntegerVariable("valXPrestant", ScrCtrlGame.XP_Next);

    }

}
