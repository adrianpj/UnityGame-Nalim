using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ---------------------------------------------
/// ---------SCR DEFENSA-------------------------
/// Gestió del botó Defensa
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 11-05-19
///     0.1 primera versió (Adrian, SENSE CODI!)
///     0.2 codi implementat
///     
/// ---------------------------------------------
/// </summary>

public class ScrDefensa : MonoBehaviour {

    public Button btn_Defensa; //El botó de la Poma en la qual cliquem per la propietat Defensa
    public bool vs1, vs2;
    int numRange;

    public AudioSource DanyPlayer; //Interfície d'àudio

    public void DefensaPlayer()
    {
        ScrVida cartaplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ScrVida>(); // Accedim a la seva propietat Vida
        ScrPlayer sdefensaP = GameObject.FindGameObjectWithTag("Player").GetComponent<ScrPlayer>(); // Accedim la seva propietat Defensa
        ScrDados tiradaus = GameObject.FindGameObjectWithTag("scripts").GetComponent<ScrDados>(); // Accedim a la variable dels daus

        tiradaus.Tirar4dados(); //Fer la tirada

        numRange = Mathf.Min(tiradaus.dado1 + tiradaus.dado2 + tiradaus.dado3 + tiradaus.dado4);
        numRange += sdefensaP.defensa; //Sumem la seva defensa

        if (numRange >= 7) //Si supera la tirada
        {
            cartaplayer.immune = true; //El Jugador queda lliure del dany
            btn_Defensa.interactable = false; //L'objecte quedarà desactivat ja que no podrà accedir
        }

        else //Si no el supera, l'enemic es posarà a atacar
        {
            if (vs1)
            {
                ScrAtacar satacar = GetComponent<ScrAtacar>();
                satacar.targetBarda = true;
            }
            else if (vs2) { ScrAtacar1 satacar1 = GetComponent<ScrAtacar1>(); }

            ScrDaño sdañoB = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ScrDaño>();
            cartaplayer.vidaPlayer = cartaplayer.vidaPlayer - sdañoB.dañoNPC;
            DanyPlayer.Play();
        }

    }

}
