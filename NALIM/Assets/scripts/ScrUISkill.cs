using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ---------------------------------------------
/// ---------SCR UI SKILL------------------------
/// Gestió del control de la UI de les habilitats
/// 
/// Versió 0.2
/// Carlos Serrano
/// Data 05-04-19
///     0.1 primera versió
///     0.2 Incorporació del text de l'experiència
/// ---------------------------------------------
/// </summary>

public class ScrUISkill : MonoBehaviour {

    public Text[] PointSkill_tex; //Text dels punts de cada habilitat
    public Text PointTotal_tex; //Text dels punts de l'ATRIBUT
    public Text PointLevel_tex; //Text del nivell

    public AudioSource snd_PencilWrite; //So del llapis

    void Update() //Actualització texts
    {
        if (PointTotal_tex) PointTotal_tex.text = ScrCtrlGame.Point_total.ToString();
        if (PointLevel_tex) PointLevel_tex.text = ScrCtrlGame.Pers_level.ToString();

        for (int i = 0; i < 8; i++) //Actualització de cada NOMBRE D'HABILITAT
        {
            PointSkill_tex[i].text = ScrCtrlGame.pointSkill[i].ToString();
        }

    }

    public void SetNumberSkin(int num)
    {
        if (ScrCtrlGame.Point_total > 0 && ScrCtrlGame.pointSkill[num] < (3 + ScrCtrlGame.Pers_level)) //Si el jugador NO HA exhaurit el nombre total de punts
        {
            snd_PencilWrite.Play();
            ScrCtrlGame.pointSkill[num]++; //Suma punts a l'habilitat
            ScrCtrlGame.Point_total--; //Mentre l'altre paràmetre, la d'ATRIBUTS resta punts
        }

    }

    public void ReturnNumberSkin(int num)
    {
        if(ScrCtrlGame.pointSkill[num] > 0)
        {
            snd_PencilWrite.Play();
            ScrCtrlGame.pointSkill[num]--; //Resta punts a l'habilitat
            ScrCtrlGame.Point_total++; //Mentre l'altre paràmetre, la d'ATRIBUTS suma punts
        }
    }

}
