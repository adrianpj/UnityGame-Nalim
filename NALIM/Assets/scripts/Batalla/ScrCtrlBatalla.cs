using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

/// <summary>
/// ---------------------------------------------
/// ---------SCR CTRL BATALLA--------------------
/// Gestió del control del joc dins el COMBAT
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 03-04-19
///     0.1 primera versió
///     
/// ---------------------------------------------
/// </summary>

public class ScrCtrlBatalla : MonoBehaviour {

    public GameObject Game_lost; //Pantalla de mort
    public GameObject Game_win; //Pantalla de victòria
    public Canvas Batalla; //El Canvas que s'usa durant el combat
    public Canvas btn_Inventari; //El Canvas que s'usa el botó d'inventari
    public Flowchart Win; //Variables a la pantalla de victòria

    static bool HasLost = false; //Ha perdut?
    static bool HasWin = false; //Ha guanyat?
    public static bool HelpedTitan; //El Titan ha suportat al Player
    public static bool BattleFinalised; //Si el combat ha finalitzat

    public static float crono = 0f; //Cronòmetre per comptar els temps i torns

    void Start() //Inicialització variables
    {
        HasLost = false;
        HasWin = false;
        HelpedTitan = false;
        BattleFinalised = false;
    }

    void FixedUpdate()
    {
        crono += Time.deltaTime; //El temps que anirà sumant el crono
    }

    void Update() //Actualitza paràmetres quan és convenient
    {
        Win.SetBooleanVariable("if_TitanHelp", HelpedTitan);

        if (HasLost || HasWin) { Batalla.enabled = false; btn_Inventari.enabled = false; }

        if (HasLost) Game_lost.SetActive(true);
        else if (HasWin) Game_win.SetActive(true);

    }

    public static void Partida_Gover() //Determina quan el JUGADOR perd la batalla
    {
        BattleFinalised = true;
        HasLost = true;
    }

    public static void Partida_Win() //Determina que el JUGADOR ha guanyat la batalla
    {
        BattleFinalised = true;
        HasWin = true;
    }
}
