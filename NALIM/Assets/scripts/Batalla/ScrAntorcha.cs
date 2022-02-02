using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrAntorcha : MonoBehaviour {

    /// <summary>
    /// ---------------------------------------------
    /// ---------SCR ANTORCHA------------------------
    /// Script por si pulsas la antorcha de los sacerdotes , las antorchas se apagan y el Titán se vuelve tu aliado una vez se apagan todas 
    /// 
    /// ---------------------------------------------
    /// </summary>

    public GameObject titan;
    public GameObject[] antorcha;
    public Transform panelAliado;
    int antorchasTotal = 2;

   
    public void Antorcha(int Ant)
    {
        ScrAtacar1 satacar = GameObject.FindGameObjectWithTag("scripts").GetComponent<ScrAtacar1>();
        ScrDaño sdañoB = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ScrDaño>();
        antorchasTotal--;

        antorcha[Ant].SetActive(false);


        if (antorchasTotal == 0)
        {
            ScrVida PlayerMain_vidas = GameObject.FindGameObjectWithTag("Player").GetComponent<ScrVida>();
            ScrVida Titan_vidas = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ScrVida>();

            PlayerMain_vidas.vidaPlayer += Titan_vidas.vidaNPC;
            
            satacar.Spr_Enemy[1].sprite = satacar.Sprites[5];
            satacar.Spr_Enemy[2].sprite = satacar.Sprites[5];

            titan.transform.SetParent(panelAliado);
            titan.tag = "Aliado";
            ScrCtrlBatalla.HelpedTitan = true;
            satacar.titanEnemy = false; //El titán se hace aliado y deshabilita su estado como enemigo
            satacar.todosmuertos--;
        }
    }

    
}
