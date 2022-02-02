using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ---------------------------------------------
/// ---------SCR MENU GAME-----------------------
/// Gestió del menú opcional dins del joc
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 19-05-19
/// ---------------------------------------------
/// </summary>

public class ScrMenuGame : MonoBehaviour
{
    public GameObject UI_MenuGame;
    public bool in_battle;
    bool menu_activated = true; //Permet mutar/desmutar menú

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !ScrCtrlGame.MovieActive)
        {
            Time.timeScale = 0;
            btn_Continue();

        }

    }

    public void btn_Continue()
    {

        UI_MenuGame.SetActive(menu_activated);
        if (menu_activated == false) Time.timeScale = 1;
        menu_activated = !menu_activated;
    }

    public void btn_Exit()
    {
        Application.Quit();
    }

    public void btn_BackMenu()
    {
        SceneManager.LoadScene("00-MainMenu");
    }


}


