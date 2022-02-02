using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ---------------------------------------------
/// ---------SCR END CREDITS---------------------
/// Gestió del control dels crèdits
/// 
/// Versió 0.2
/// Carlos Serrano
/// Data 02-05-19
///     0.1 primera versió
///     0.2 addició dels controls de les seqüències finals
/// ---------------------------------------------
/// </summary>

public class ScrEndCredits : MonoBehaviour {

    float temps_Over; //temps que resta a la pantalla

    public GameObject UI_Credits; // Els crèdits
    public GameObject UI_Movie; // Interfície de la pel·lícula
    public GameObject UI_Movie1st; // Primera pel·lícula abans dels crèdits
    public GameObject UI_PostMovie; // La pel·lícula que anirà després dels crèdits
    public GameObject FlowMusic; //Un mixer de Fungus en la qual aniran sonant les diferents cançons
    public AudioSource[] Mix; //Les músiques que van sonant

    public float temps1; //El 1er temps cronometrable a la seqüència de la primera pel·lícula
    public float temps2; //El 2on temps cronometrable a la seqüència dels crèdits
    public float temps3; //El 3er temps cronometrable a la seqüència de la pel·lícula final

    bool[] active = new bool[3]; //Activa i desactivarà en seqüència els diferents GameObjects


    // Use this for initialization
    void Start () {

        Cursor.visible = false;
        temps_Over = 0;
        active[0] = false;
        for (int i = 1; i < active.Length; i++) active[i] = true; //Desctiva tots

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        // ***** INTERFÍCIE FI DEL JOC ****************
        temps_Over += Time.deltaTime; //comptador de temps

        if ((temps_Over >= temps1 || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0)) && !active[0])
        {
            Cursor.visible = true;
            temps_Over = temps1;
            UI_Movie.SetActive(false);
            UI_Movie1st.SetActive(false);
            UI_Credits.SetActive(true);
            FlowMusic.SetActive(true);
            active[0] = true;
            active[1] = false;
        }

        else if ((temps_Over >= temps2 || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0)) && !active[1])
        {
            Cursor.visible = false;
            temps_Over = temps2;
            UI_Credits.SetActive(false);
            UI_Movie.SetActive(true);
            UI_PostMovie.SetActive(true);
            FlowMusic.SetActive(false);
            active[1] = true;
            active[2] = false;

            for (int i = 0; i < Mix.LongLength; i++)
            {
                Mix[i].Stop();
            }
        }

        else if ((temps_Over >= temps3 || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0)) && !active[2])
            //Carrega el menú principal
        {
            Cursor.visible = true;
            SceneManager.LoadScene("00-MainMenu");
        }

	}
}
