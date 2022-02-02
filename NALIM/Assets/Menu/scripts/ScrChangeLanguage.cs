using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ---------------------------------------------
/// ---------SCR CHANGE LANGUAGE------------------
/// Gestió dels botons del canvi de llengua
/// 
/// Versió 0.2
/// Carlos Serrano
/// Data 07-03-19
///     0.1 primera versió
///     0.2 renombrament de l'script
/// ---------------------------------------------
/// </summary>

public class ScrChangeLanguage : MonoBehaviour
{

    public void btn_F_CanviLlenguaRwd() //Sentit REWIND
    {


        switch (ScrCtrlGame.numLanguage) //Trobada d'una llengua amb el seu valor numèric en sentit REWIND
        {
            case 0:
                ScrLocalization.SetCurrentLanguage(SystemLanguage.Catalan); //Català
                //ScrCtrlGame.idLanguage = 2;
                break;

            case 1:
                ScrLocalization.SetCurrentLanguage(SystemLanguage.English); //Anglès
                //ScrCtrlGame.idLanguage = 0;
                break;

            default:
                ScrLocalization.SetCurrentLanguage(SystemLanguage.Spanish); //Castellà
                //ScrCtrlGame.idLanguage = 1;
                break;


        }

        ScrCtrlGame.numLanguage--; //Número d'idioma anterior
        if (ScrCtrlGame.numLanguage < 0) ScrCtrlGame.numLanguage = 2; //Restableix l'últim número
    }

    public void btn_F_CanviLlenguaFwd() //Sentit FORWARD
    {

        switch (ScrCtrlGame.numLanguage) //Trobada d'una llengua amb el seu valor numèric en sentit FORWARD
        {
            case 0:
                ScrLocalization.SetCurrentLanguage(SystemLanguage.Spanish); //Castellà
                //ScrCtrlGame.idLanguage = 1;
                break;

            case 1:
                ScrLocalization.SetCurrentLanguage(SystemLanguage.Catalan); //Català
                //ScrCtrlGame.idLanguage = 2;
                break;

            default:
                ScrLocalization.SetCurrentLanguage(SystemLanguage.English); //Anglès
                //ScrCtrlGame.idLanguage = 0;
                break;


        }

        ScrCtrlGame.numLanguage++; //Número d'idioma següent
        if (ScrCtrlGame.numLanguage > 2) ScrCtrlGame.numLanguage = 0; //Restableix el primer número
    }
}
