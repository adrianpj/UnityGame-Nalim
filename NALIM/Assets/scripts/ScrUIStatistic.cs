using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ---------------------------------------------
/// ---------SCR UI STATISTIC--------------------
/// Gestió del control de la UI dels atributs
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 05-04-19
///     0.1 primera versió
/// ---------------------------------------------
/// </summary>

public class ScrUIStatistic : MonoBehaviour {

    //Els texts dins del primer menú d'habilitats
    public Text[] PointStatistic_tex; //Text dels punts de cada atribut
    public Text PointStatisticTotal_tex; // Aquest és el text per al resultat final dels 4 atributs

    //Actualització texts
    void Update () {

        PointStatisticTotal_tex.text = ScrCtrlGame.Pers_HP_max.ToString();

        //Actualització de cada NOMBRE D'ATRIBUTS
        for (int i = 0; i < 4; i++) PointStatistic_tex[i].text = ScrCtrlGame.pointStatistic[i].ToString();


    }
}
