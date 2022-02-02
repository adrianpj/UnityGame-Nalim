using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ---------------------------------------------
/// ---------SCR BLOOD---------------------------
/// Gestió del control de la sang
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 16-05-19
///     0.1 primera versió
/// ---------------------------------------------
/// </summary>

public class ScrBlood : MonoBehaviour {

    public Image blood; //L'imatge en què associarem el banc de sang

    // La sang influeix en el número de vida del personatge
    void Update () {

        var nblooA = blood.color;

        if ((ScrCtrlGame.Pers_HP < (ScrCtrlGame.Pers_HP_max / 2)) && (ScrCtrlGame.Pers_HP > (ScrCtrlGame.Pers_HP_max / 3)))
        //Dos terços inferiors, per ex. 30 a 15
        {
            nblooA.a = 0.1f; //És menys intensa
            blood.color = nblooA;
        }

        else if (ScrCtrlGame.Pers_HP < (ScrCtrlGame.Pers_HP_max / 3) && (ScrCtrlGame.Pers_HP > 7))
        //Tres terços inferiors, per ex. 30 a 10
        {
            nblooA.a = 0.15f; //Més intensa
            blood.color = nblooA;
        }

        else if (ScrCtrlGame.Pers_HP <= 7)
        //Quatre terços inferiors, per ex. 30 a 7
        {
            nblooA.a = 0.2f; //Absoluta
            blood.color = nblooA;
        }

        else if (ScrCtrlGame.Pers_HP > (ScrCtrlGame.Pers_HP_max / 2))
        //Cap terç inferior, per ex. 30 a 30
        {
            nblooA.a = 0f; //Nul·la
            blood.color = nblooA;
        }

        /*
        var nblooA = blood.color;

        if (ScrCtrlGame.Pers_HP < 7)
        {
            nblooA.a = 0.2f; //És més intensa
            blood.color = nblooA;
        }

        else
        {
            nblooA.a = 0f; //Nul·la
            blood.color = nblooA;
        }
        */
    }
}
