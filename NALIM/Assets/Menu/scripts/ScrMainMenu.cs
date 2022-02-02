using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// ---------------------------------------------
/// ---------SCR MAIN MENU-----------------------
/// Gestió del control de MAIN MENÚ
/// 
/// Versió 0.2
/// Carlos Serrano
/// Data 04-03-19
/// 
///     0.1 primera versió
///     0.2 canvis en les funcions dels botons, optimització
/// ---------------------------------------------
/// </summary>


public class ScrMainMenu : MonoBehaviour {

    public GameObject menu_portal, menu_Config, menu_PantallaNouJoc_base, menu_PantallaNouJoc1, menu_PantallaNouJoc2, menu_PantallaNouJoc3; //declaració variables SetActive

    // Use this for initialization
    void Start () {

        //**Inicialització menú***

        if (menu_portal)
        {
            menu_portal.SetActive(true);
            menu_Config.SetActive(false);
            menu_PantallaNouJoc_base.SetActive(false);
            menu_PantallaNouJoc1.SetActive(true);
            menu_PantallaNouJoc2.SetActive(false);
            menu_PantallaNouJoc3.SetActive(false);
        }



        //************************

        ScrCtrlGame.is_intestLang_changed = true; //inicialització variable idioma

        //***NOTA: La llengua de defecte s'activarà el que està predeterminat pel sistema.
        //Si és a ser el primer arranc des del PC
        if (Application.systemLanguage == SystemLanguage.English)
        {
            ScrCtrlGame.numLanguage = 0;
        }

        if (Application.systemLanguage == SystemLanguage.Spanish)
        {
            ScrCtrlGame.numLanguage = 1;
            
        }

        if (Application.systemLanguage == SystemLanguage.Catalan)
        {
            ScrCtrlGame.numLanguage = 2;
            
        }

        else
        {
            ScrLocalization.SetCurrentLanguage(SystemLanguage.English);
            ScrCtrlGame.numLanguage = 0;
        }

    }
	
	// Update is called once per frame
	void Update () {

        AdjLanguage();

    }

    public void btn_F_Sortir() //Sortida de l'aplicació
    {
        Application.Quit();
    }

    public void btn_F_LoadScene()
    {
        ScrCtrlGame.Pers_HP_max = ScrCtrlGame.Pers_HP;
        SceneManager.LoadScene("00-EnterGame");

    }

    public void CheckName()
    {
        if (ScrCtrlGame.is_ifield_NomPlayer_changed)
        {

        }

        else
        {
            ScrCtrlGame.nomJugador = "NALIM";
        }
    }
    
    private void AdjLanguage() //Actualitza totes les components dels textos de MENÚ a la llengua escollida
    {
        if (ScrCtrlGame.numLanguage == 0)
        {
            ScrLocalization.SetCurrentLanguage(SystemLanguage.English); //Anglès
        }

        if (ScrCtrlGame.numLanguage == 1)
        {
            ScrLocalization.SetCurrentLanguage(SystemLanguage.Spanish);  //Castellà
        }

        if (ScrCtrlGame.numLanguage == 2)
        {
            ScrLocalization.SetCurrentLanguage(SystemLanguage.Catalan);  //Català
        }

    }

}
