using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ---------------------------------------------
/// ---------SCR VIDA----------------------------
/// Script para establecer las estadísticas de vida en el combate
/// 
/// ---------------------------------------------
/// </summary>

public class ScrVida : MonoBehaviour {

    [SerializeField]
    public int vidaPlayer;
    public int vidaNPC ;

    // Immune al ataque (Especialmente, la defensa que debe superar del Player)
    public bool immune;

    void Start()
    {
        ScrPlayer splayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ScrPlayer>();
        ScrDados sdados = GameObject.FindGameObjectWithTag("scripts").GetComponent<ScrDados>();

        immune = false;

        sdados.Tirar4dados();

    }
}
