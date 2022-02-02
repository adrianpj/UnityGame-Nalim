using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ---------------------------------------------
/// ---------SCR ATACAR--------------------------
/// 
///     SCRIPT SOLO FUNCIONA SI ES UN 1V1 (PLAYER VS CUALQUIER ENEMIGO)
/// 
/// Versión 0.1
/// 09-05-19
///     0.1 primera versión
///
/// ---------------------------------------------
/// </summary>

public class ScrAtacar : MonoBehaviour {

    // Objetivo al que se ataca
    public bool targetPlayer = false, targetBarda = false, targetTitan = false, targetEnemy = false, targetNila = false, targetJack = false;
    public Button bBarda, bSword, bInventory, bDefense;
    public GameObject Barda, Player;

    public Sprite[] Sprites;
    public Image Spr_Enemy;

    // Controlar donde está el Player y si ha atacado
    bool encasa = true; //Si es true es que no ataca o ya ha acabado su turno
    bool atacar = false; //Saber si el player ha atacado
    bool primerturno = false; //El Player ataca primero

    //AudioSource
    public AudioSource PlayerDamage, SndEnemyAttack;

    private void Start()
    {        
        bBarda.interactable = false;
    }

    private void Update()
    {
        if (!ScrCtrlBatalla.BattleFinalised)
        {

            ScrDados sdados = GameObject.FindGameObjectWithTag("scripts").GetComponent<ScrDados>(); // Para acceder al script Scr_Dados
            ScrDaño sdañoP = GameObject.FindGameObjectWithTag("Player").GetComponent<ScrDaño>(); // Para acceder al daño que tiene el player
            ScrDaño sdañoB = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ScrDaño>(); // Para acceder al daño que tiene el barda
            ScrVida cartaplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ScrVida>(); // Para acceder a la vida del player
            ScrVida cartabarda = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ScrVida>(); // Para acceder a la vida del barda

            //   ---------------------------------------------------------------------
            //   ---------------- Para saber a quien ha atacado el Player --------------
            //   ---------------------------------------------------------------------

            if (targetBarda && !encasa)
            {

                if (ScrCtrlBatalla.crono > 1f && primerturno)
                {

                    cartabarda.vidaNPC -= sdañoP.dañoPlayer;

                    if (atacar && !cartaplayer.immune)
                    {
                        Spr_Enemy.sprite = Sprites[2];
                        SndEnemyAttack.Play();
                    }

                    primerturno = false;

                }

                if (ScrCtrlBatalla.crono > 2f)
                {

                    targetBarda = false;

                    bSword.interactable = true;
                    bInventory.interactable = true;

                    encasa = true;

                    if (atacar && !cartaplayer.immune)
                    {

                        cartaplayer.vidaPlayer = cartaplayer.vidaPlayer - sdañoB.dañoNPC;
                        Spr_Enemy.sprite = Sprites[0];
                        bDefense.interactable = true;

                        PlayerDamage.Play();
                        atacar = false;
                    }


                }

                Destruccion();

            }
        }
        
    }

    public void Atacar()
    {      
        ScrDados sdados = GameObject.FindGameObjectWithTag("scripts").GetComponent<ScrDados>();

        bBarda.interactable = true;
        bSword.interactable = false;
        encasa = false;
        primerturno = true;
        atacar = true;
        sdados.Tirar4dados();
    }	 
    
    

    private void Destruccion()
    {
        ScrVida cartas = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ScrVida>(); // Para acceder a la vida del barda
        ScrVida vidaplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ScrVida>();

        if (cartas.vidaNPC <= 0)
        {
            ScrCtrlBatalla.Partida_Win();

        }
        
        if (vidaplayer.vidaPlayer <= 0)
        {
            ScrCtrlBatalla.Partida_Gover();
        }
    }
}

