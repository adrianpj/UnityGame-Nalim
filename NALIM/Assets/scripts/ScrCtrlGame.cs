using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// ---------------------------------------------
/// ---------SCR CTRL GAME-----------------------
/// Gestió del control del joc.
/// 
/// Versió 0.2
/// Carlos Serrano
/// Data 05-04-19
///     0.1 primera versió
///     0.2 optimització de l'script
///     0.3 afegit valors estàtics del jugant principal
/// ---------------------------------------------
/// </summary>


public class ScrCtrlGame : MonoBehaviour {

    //-----------------------Declaració valors numèrics dels objectes
    public static int numLanguage = 0;
    public static int numMascara = 0;
    public static bool ToHelpBattle = false; // Posiciona a la Nila i en Jack al combat final
    public static bool MovieActive = false; // No podrà passar a menú del joc quan s'activi una pel·lícula

    //-----------------------------------------Declaració del JUGADOR
    public static string nomJugador; //El seu nom
    public static int[] pointSkill = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 }; //Punts per cada habilitat
    public static int[] pointStatistic = new int[4] { 0, 0, 0, 0}; //Punts per cada atribut
    public static int[] pointItem = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 }; // Quantitat per cada ítem
    public static int[] LimitTirada = new int[4] { 0, 0, 0, 0 }; //Quantes tirades màxim pot fer per cada atribut
    public static int Pers_level = 0; //El nivell adquirit
    public static int Point_total = 5; //Total a repartir
    public static int Pers_HP = 0; //La vida del personatge
    public static int Pers_HP_max; //La vida màxima del personatge
    public static int XP_Point = 0; //Els punts d'experiència que tinc ara
    public static int XP_Next = 10; //Quants punts d'experiència necessito per arribar al següent nivell
    public static bool[] activated_army = { false, false, false, false, false, false, false, false }; // Posa els valors de l'ítem de les ARMES

    public static bool EstaInventari = false; //Si passa variables des de l'inventari (la vida)
    public static bool tiradaVida = false; //Tirada de la vida
    public static bool dauAdd = false; //Dau addicional
    //-----------------------------------------

    //-----------------------Declaració booleana del NOM DE JUGADOR
    public static bool is_in_menu = false;
    public static bool is_ifield_NomPlayer_changed;
    public static bool is_intestLang_changed = false;

    //-----------------------Declaració del VOLUM
    public AudioMixer generalAud;

    //-----------------------Declaració de la sensibilitat del RATOLÍ
    public static float Adjsensitivity;

    public static float tempsJoc = 0f; //Comptador de temps dins del JOC

    // Use this for initialization
    void Start () {

        tempsJoc = 0f; //inicialització temps dins del JOC

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        tempsJoc += Time.deltaTime; //Suma de temps

        if (Input.GetKeyDown(KeyCode.X)) Application.Quit(); //Sortida de l'aplicació

    }

    public void SetName(string Adj_name) //Actualitza el camp del NOM DEL JUGADOR
    {
        nomJugador = Adj_name;
        if (nomJugador == "" && nomJugador == " ") is_ifield_NomPlayer_changed = false; //Cancel·lació booleana EL NOM CANVIAT, si és el cas
        else is_ifield_NomPlayer_changed = true; //Acceptació booleana EL NOM CANVIAT, si és el cas

    }


    public void SetSensitivity(float Adj_sensi) //Ajusta la precisió del RATOLÍ
    {
        ScrCtrlGame.Adjsensitivity = Adj_sensi;
    }

}
