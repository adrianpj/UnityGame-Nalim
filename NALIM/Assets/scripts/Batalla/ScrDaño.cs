using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ---------------------------------------------
/// ---------SCR DAÑO----------------------------
/// Script para establecer el daño que inflinjirá
/// 
/// ---------------------------------------------
/// </summary>

public class ScrDaño : MonoBehaviour {

    public int dañoPlayer;
    public int dañoNPC;

    public int HojaSprite; //¿A qué hoja de sprite pertenece?

    // Armas con su bonificacion de daño
    int sinarma = 0;
    int armaarco = 3, armabaston = 3;
    int armadaga = 2;
    int armahacha = 4, armaespada = 4, armamaza = 4;
    int armacadena = 6;
    public bool arco, daga, hacha, espada, maza, baston, nada, cadena, verarco, verdaga, verhacha, verespada, vermaza, verbaston, vernada, vercadena;

    private void Start()
    {
        verarco = true;
    }

    private void Update()
    {
        if (!ScrCtrlBatalla.BattleFinalised)
        {

            ScrDados sdados = GameObject.FindGameObjectWithTag("scripts").GetComponent<ScrDados>();
            ScrPlayer splayer = GetComponent<ScrPlayer>();
            //GameObject soybarda = GameObject.FindGameObjectWithTag("Barda"); // Acceder barda 
            GameObject soyenemy = GameObject.FindGameObjectWithTag("Enemy"); // Acceder Enemy 

            //  -----------------------------------------------------------------------------
            //  ------------------ CONTROLAR LOS DAÑOS DEPENDIENDO DEL ARMA ------------------
            //  ------------------------------------------------------------------------------



            // Daño Player 
            if (hacha || espada || maza)
            {
                dañoPlayer = sdados.dado1 + armahacha;
                dañoPlayer = sdados.dado1 + armaespada;
                dañoPlayer = sdados.dado1 + armamaza;

                /*if (splayer.fuerza == 18)
                {                
                    dañoPlayer = sdados.dado1 + armahacha + 1;
                }*/
            }
            else if (daga)
            {
                dañoPlayer = sdados.dado1 + armadaga;
            }
            else if (arco || baston || cadena)
            {
                dañoPlayer = sdados.dado1 + armaarco;
                dañoPlayer = sdados.dado1 + armabaston;
            }

            else if (nada)
            {
                dañoPlayer = sdados.dado1;
            }

            else if (nada && splayer.fuerza == 18)
            {
                dañoPlayer = sdados.dado1 + 1;
            }

            // Daño de los NPC

            if (soyenemy.name == "Titan")
            {
                ScrAtacar1 satacar = GameObject.FindGameObjectWithTag("scripts").GetComponent<ScrAtacar1>();

                if (satacar.titanEnemy)
                {
                    int armatitan = Random.Range(0, 2);

                    if (armatitan == 1)
                    {
                        dañoNPC = armacadena;
                    }
                    else dañoNPC = armaespada;
                    
                }

            }

            else if (soyenemy.name == "Enemigo1" || soyenemy.name == "Enemigo2")
            {
                dañoNPC = sdados.dado3 + armamaza;
            }

            else if (soyenemy.name == "NilaJack")
            {
                dañoNPC = sdados.dado3 + armabaston + 2;
            }

            else if (soyenemy.name == "Nila")
            {
                dañoNPC = sdados.dado3 + armabaston;
            }
            else if (soyenemy.name == "Jack")
            {
                dañoNPC = sdados.dado3 + 2;
            }
            else if (soyenemy.name == "Barda")
            {
                dañoNPC = sdados.dado3;
            }
            else if (soyenemy.name == "Enemy")
            {
                dañoNPC = sdados.dado3 + armamaza;
            }


        }

    }
    
    //---------------------------------------------------------------------------
}

