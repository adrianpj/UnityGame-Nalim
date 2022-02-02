using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ---------------------------------------------
/// ---------SCR CHANGE MASK---------------------
/// Gestió dels botons del canvi de màscara
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 01-05-19
///     0.1 primera versió
///     0.2 renombrament de l'script
///     0.3 variables establertes
/// ---------------------------------------------
/// </summary>

public class ScrChangeMask : MonoBehaviour {

    ScrUIMask MaskPlayer;

    public void btn_F_SeleMascaraRWD() //Sentit REWIND
    {
        MaskPlayer = GetComponent<ScrUIMask>();

        ScrCtrlGame.numMascara--;  //Màscara anterior

        if (ScrCtrlGame.numMascara < 0) //Condició en què anirem a l'última màscara
        {
            ScrCtrlGame.numMascara = 3; //Restableix l'última MÀSCARA
            for (int i = 0; i < 3; i++) MaskPlayer.p_mask[i].enabled = false;
        }

        else MaskPlayer.p_mask[ScrCtrlGame.numMascara+1].enabled = false;
        MaskPlayer.p_mask[ScrCtrlGame.numMascara].enabled = true;
       
    }

    public void btn_F_SeleMascaraFWD()  //Sentit FORWARD
    {
        MaskPlayer = GetComponent<ScrUIMask>();

        ScrCtrlGame.numMascara++; //Màscara següent

        if (ScrCtrlGame.numMascara > 3) //Condició en què anirem a la primera màscara
        {
            ScrCtrlGame.numMascara = 0; //Restableix la primera MÀSCARA
            for (int i = 3; i > 0; i--) MaskPlayer.p_mask[i].enabled = false;
        }

        else MaskPlayer.p_mask[ScrCtrlGame.numMascara-1].enabled = false;
        MaskPlayer.p_mask[ScrCtrlGame.numMascara].enabled = true;

    }
}
