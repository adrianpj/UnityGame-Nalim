using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ---------------------------------------------
/// ---------SCR BATTLE BLOOD--------------------
/// Gestió del control de la sang
/// 
/// (s'ha de canviar
/// ---------------------------------------------
/// </summary>

public class ScrBloodBattle : MonoBehaviour {

    public Image blood; //L'imatge en què associarem el banc de sang

    // La sang influeix en el número de vida del personatge, inversament proporcional al màxim
    void Update () {

        var nblooA = blood.color;

        if ((ScrCtrlGame.Pers_HP < (ScrCtrlGame.Pers_HP_max / 2)) && (ScrCtrlGame.Pers_HP > (ScrCtrlGame.Pers_HP_max / 3)))
            //Dos terços inferiors, per ex. 30 a 15
        {
            nblooA.a = 0.3f; //És menys intensa
            blood.color = nblooA;
        }

        else if (ScrCtrlGame.Pers_HP < (ScrCtrlGame.Pers_HP_max / 3) && (ScrCtrlGame.Pers_HP > (ScrCtrlGame.Pers_HP_max / 4)))
        //Tres terços inferiors, per ex. 30 a 10
        {
            nblooA.a = 0.55f; //Més intensa
            blood.color = nblooA;
        }

        else if (ScrCtrlGame.Pers_HP < (ScrCtrlGame.Pers_HP_max / 4))
        //Quatre terços inferiors, per ex. 30 a 8
        {
            nblooA.a = 1f; //Absoluta
            blood.color = nblooA;
        }

        else if (ScrCtrlGame.Pers_HP > (ScrCtrlGame.Pers_HP_max / 2))
        //Cap terç inferior, per ex. 30 a 30
        {
            nblooA.a = 0f; //Nul·la
            blood.color = nblooA;
        }

    }
}
