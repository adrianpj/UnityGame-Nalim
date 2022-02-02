using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ---------------------------------------------
/// ---------SCR SPLASH--------------------------
/// Gestió de l'inici de l'aplicació
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 16-02-19
/// ---------------------------------------------
/// </summary>

public class ScrSplash : MonoBehaviour {

    public GameObject UI_Splash;
    public GameObject UI_Movie;
    bool activat = false;

    void Start()
    {
        Cursor.visible = false;
    }


	// Update is called once per frame
	void Update () {

        if ((ScrCtrlGame.tempsJoc >= 10f || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0)) && !activat)
        {
            UI_Movie.SetActive(false);
            UI_Splash.SetActive(true);
            activat = true;
            Cursor.visible = true;
        }

        else if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0)) && activat) //si es prem la tecla
        {
            CarregaMenu();
        }
		
	}

    public void CarregaMenu()
    {
        SceneManager.LoadScene("00-MainMenu"); //carrega el menú
    }
}
