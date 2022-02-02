using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ---------------------------------------------
/// ---------SCR PLAYER--------------------------
/// Script para establecer las estadísticas del Player en el combate
/// 
/// ---------------------------------------------
/// </summary>

public class ScrPlayer : MonoBehaviour {

    ScrVida PlayerMain_vides;
    ScrDaño PlayerMain_arma;

    // var Atributos Principales
    public string nombre;
    public int fuerza = 0; 
    public int destreza;
    public int percepcion;
    public int resistencia = 1;
    public int experiencia = 0;

    // Habilidades
    public int defensa;
    public int memorizar;
    public int desarmado;
    public int trepar;
    public int armascc;  // Armas cuerpo a cuerpo
    public int armap;    // Armas de proyectil
    public int supervivencia;
    public int habespecial;  // Habilidad especial

    // Use this for initialization
    void Start () {

        PlayerMain_vides = GetComponent<ScrVida>();
        PlayerMain_arma = GetComponent<ScrDaño>();

        nombre = ScrCtrlGame.nomJugador;
        fuerza = ScrCtrlGame.pointStatistic[0];
        destreza = ScrCtrlGame.pointStatistic[1];
        percepcion = ScrCtrlGame.pointStatistic[2];
        resistencia = ScrCtrlGame.pointStatistic[3];
        experiencia = ScrCtrlGame.Pers_level;

        defensa = ScrCtrlGame.pointSkill[0];
        memorizar = ScrCtrlGame.pointSkill[1];
        desarmado = ScrCtrlGame.pointSkill[2];
        trepar = ScrCtrlGame.pointSkill[3];
        armascc = ScrCtrlGame.pointSkill[4];
        armap = ScrCtrlGame.pointSkill[5];
        supervivencia = ScrCtrlGame.pointSkill[6];
        habespecial = ScrCtrlGame.pointSkill[7];

        PlayerMain_vides.vidaPlayer = ScrCtrlGame.Pers_HP + PlayerMain_vides.vidaPlayer;


    }
	
	// Update is called once per frame
	void Update () {

        //Li ha d'actualitzar el nombre de vides SEMPRE, tanmateix si queda a l'inventari com si no.
        if (ScrCtrlGame.EstaInventari) PlayerMain_vides.vidaPlayer = ScrCtrlGame.Pers_HP;
        else ScrCtrlGame.Pers_HP = PlayerMain_vides.vidaPlayer;

        //Així com també l'arma que s'usa
        PlayerMain_arma.arco = ScrCtrlGame.activated_army[0];
        PlayerMain_arma.daga = ScrCtrlGame.activated_army[1];
        PlayerMain_arma.baston = ScrCtrlGame.activated_army[2];
        PlayerMain_arma.hacha = ScrCtrlGame.activated_army[3];
        PlayerMain_arma.espada = ScrCtrlGame.activated_army[4];
        PlayerMain_arma.cadena = ScrCtrlGame.activated_army[5];

        if (!PlayerMain_arma.arco && !PlayerMain_arma.daga && !PlayerMain_arma.baston &&
            !PlayerMain_arma.espada && !PlayerMain_arma.hacha && !PlayerMain_arma.cadena)
        {
            PlayerMain_arma.nada = true;
        }

        else
        {
            PlayerMain_arma.nada = false;
        }

    }
}

 
