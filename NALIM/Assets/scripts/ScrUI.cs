using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ---------------------------------------------
/// ---------SCR UI------------------------------
/// Gestió del control de la UI
/// 
/// Versió 0.3
/// Carlos Serrano
/// Data 05-04-19
///     0.1 primera versió
///     0.2 incorporació del codi dels daus
///     0.3 trasllat del codi dels daus a un altre script ScrUIStatistic.cs
/// ---------------------------------------------
/// </summary>


public class ScrUI : MonoBehaviour {

    public Text nom_jugador; //Text NOU JUGADOR

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!nom_jugador) return; //Retorna si actualment no estan inclosos els camps de text
        nom_jugador.text = ScrCtrlGame.nomJugador; //Actualització camp text NOU JUGADOR        

    }
}
