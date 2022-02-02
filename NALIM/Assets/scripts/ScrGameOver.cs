using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ---------------------------------------------
/// ---------SCR GAME OVER-----------------------
/// Gestió del control del G.over
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 24-01-19
/// ---------------------------------------------
/// </summary>

public class ScrGameOver : MonoBehaviour {

    float temps_Over; //temps que resta a la pantalla

	// Use this for initialization
	void Start () {

        temps_Over = 0;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        temps_Over += Time.deltaTime; //comptador de temps

        if ((temps_Over >= 8f || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0))) //Carrega el menú principal
        {

            SceneManager.LoadScene("00-MainMenu");
        }
	}
}
