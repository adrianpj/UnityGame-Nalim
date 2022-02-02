using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ---------------------------------------------
/// ---------SCR DEFAULT-------------------------
/// Gestió dels valors per defecte
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 14-04-19
///     0.1 primera versió
/// ---------------------------------------------
/// </summary>

public class ScrDefault : MonoBehaviour {

	// Reestableix els valors per defecte
	void Start () {

        ScrCtrlGame.nomJugador = "";
        ScrCtrlGame.numMascara = 0;
        for (int i = 0; i < 8; i++) ScrCtrlGame.pointSkill[i] = 0;
        for (int i = 0; i < 4; i++) ScrCtrlGame.pointStatistic[i] = 0;
        for (int i = 0; i < 7; i++) ScrCtrlGame.pointItem[i] = 0;
        for (int i = 0; i < 7; i++) ScrCtrlGame.activated_army[i] = false;
        for (int i = 0; i < 4; i++) ScrCtrlGame.LimitTirada[i] = 0;
        ScrCtrlGame.Pers_level = 0;
        ScrCtrlGame.Pers_HP = 0;
        ScrCtrlGame.Pers_HP_max = 0;
        ScrCtrlGame.XP_Point = 0;
        ScrCtrlGame.XP_Next = 10;
        ScrCtrlGame.Point_total = 5;
        ScrCtrlGame.tiradaVida = false;
        ScrCtrlGame.dauAdd = false;


    }
	
}
