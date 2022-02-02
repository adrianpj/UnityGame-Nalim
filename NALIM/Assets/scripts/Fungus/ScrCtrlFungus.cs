using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; //per a trucar qualssevol FUNCIÓ dins del Plugin

/// <summary>
/// ---------------------------------------------
/// ---------SCR CTRL FUNGUS---------------------
/// Gestió del control de Fungus.
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 16-02-19
/// ---------------------------------------------
/// </summary>

public class ScrCtrlFungus : MonoBehaviour {

    public static bool in_game_flowno1st; //activa comptador de 5s abans d'executar la funció del FUNGUS
    public static bool in_Speech; //si el Jugador està parlant amb un altre personatge

    //Declara si és a l'escena 1
    public bool in_1stScene;
    public float in_time; //Quin temps romandrà esperar
    public GameObject BKG; //Mostrarà el background un cop finalitzat el vídeo
    public GameObject UI_Movie; //La UI de la pel·lícula

    //Declaració de la FUNCIÓ FUNGUS del nivell
    public GameObject tex_FlowChart;

    // Use this for initialization
    void Start () {

        in_Speech = true; // Farà l'inventari inhabilitat durant la transició entre escenes
        in_game_flowno1st = true;
        if (in_1stScene)
        {
            Cursor.visible = false; //Amaga el cursor en la Escena1, per l'execució de la pel·lícula
            ScrCtrlGame.MovieActive = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (ScrCtrlGame.tempsJoc >= 1f && in_game_flowno1st && !in_1stScene) //Si passen dels 4s i 50ms, s'activa la funció del FUNGUS pels diàlegs i interaccions
        {
            ActiveFlowChart();
        }

        else if ((ScrCtrlGame.tempsJoc >= in_time || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0)) && in_game_flowno1st && in_1stScene)
        // En el cas d'estar a l'escena 01-Cueva. perquè hi ha un videoclip primer.
        {

            UI_Movie.SetActive(false);
            BKG.SetActive(true);
            ScrCtrlGame.MovieActive = false;
            Cursor.visible = true;
            in_1stScene = !in_1stScene;
            ScrCtrlGame.tempsJoc = 0f;


        }
    }


    void ActiveFlowChart() // Farà activar les interaccions del Fungus
    {
        in_Speech = false;
        tex_FlowChart.SetActive(true);
        in_game_flowno1st = false;
    }
}
