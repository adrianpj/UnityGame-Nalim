using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrAtacar1 : MonoBehaviour {

    /// <summary>
    /// ---------------------------------------------
    /// ---------SCR ATACAR1-------------------------
    /// 
    ///     SCRIPT SOLO FUNCIONA SI ES UN 2V2
    /// 
    /// Versión 0.1
    /// 09-05-19
    ///     0.1 primera versión
    ///
    /// ---------------------------------------------
    /// </summary>

    // Objetivo al que se ataca
    public bool targetPlayer = false,  targetTitan = false, targetEnemy = false, targetEnemy1 = false;
    public bool titanEnemy; //Si el Titan por supuesto se caracterizara como enemigo
    public Button btitan,benemy, benemy1, bSword, bInventory, bDefense;
    public GameObject Titan, Enemy, Enemy1, Player;
    public AudioSource TitanDie, Priest1Die, Priest2Die; //Los audiosources de la muerte de los enemigos

    public Sprite[] Sprites;
    public Image[] Spr_Enemy;

    // Controlar donde está el Player y si ha atacado
    bool encasa = true; //Si es true es que no ataca o ya ha acabado su turno
    bool atacar = false; //Saber si el player ha atacado 
    bool primerturno = false; //El Player ataca primero

    public int todosmuertos = 3; //Para saber si han muerto el titan y los enemigos

    //AudioSource
    public AudioSource PlayerDamage;
    public AudioSource[] SndEnemyAttack;

    void Start()
    {
        btitan.interactable = false;
        benemy.interactable = false;
        benemy1.interactable = false;
    }

    void Update()
    {
        if (!ScrCtrlBatalla.BattleFinalised)
        {

            ScrDados sdados = GameObject.FindGameObjectWithTag("scripts").GetComponent<ScrDados>(); // Para acceder al script Scr_Dados
            ScrDaño sdañoP = GameObject.FindGameObjectWithTag("Player").GetComponent<ScrDaño>(); // Para acceder al daño que tiene el player
            ScrDaño sdañoB = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ScrDaño>(); // Para acceder al daño que tiene los enemigos
            ScrVida cartaplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ScrVida>(); // Para acceder a la vida del player
            ScrVida cartas = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ScrVida>(); // Para acceder a la vida de enemigos

            //   ---------------------------------------------------------------------
            //   ---------------- Para saber a quien ha atacado el Player --------------
            //   ---------------------------------------------------------------------

            if ((targetTitan || targetEnemy || targetEnemy1) && !encasa)
            {
                if (ScrCtrlBatalla.crono > 1f && primerturno)
                {

                    cartas.vidaNPC -= sdañoP.dañoPlayer;

                    Destruccion();

                    if (atacar && !cartaplayer.immune)
                    {

                        if (targetTitan)
                        {
                            Spr_Enemy[sdañoB.HojaSprite / 3].sprite = Sprites[2 + sdañoB.HojaSprite];
                            SndEnemyAttack[0].Play();

                        }
                        if (targetEnemy) SndEnemyAttack[1].Play();
                        if (targetEnemy1) SndEnemyAttack[2].Play();
                    }

                    primerturno = false;

                }

                if (ScrCtrlBatalla.crono > 2f)
                {

                    if (targetTitan) targetTitan = false;
                    if (targetEnemy) targetEnemy = false;
                    if (targetEnemy1) targetEnemy1 = false;

                    bSword.interactable = true;
                    bInventory.interactable = true;

                    encasa = true;

                    if (atacar && !cartaplayer.immune)
                    {
                        cartaplayer.vidaPlayer -= sdañoB.dañoNPC;
                        if (targetTitan)
                        {
                            Spr_Enemy[sdañoB.HojaSprite / 3].sprite = Sprites[0 + sdañoB.HojaSprite];
                        }

                        bDefense.interactable = true;

                        PlayerDamage.Play();
                        atacar = false;
                    }

                    Destruccion();
                }

            }


        }

    }

    public void Atacar()
    {      
        ScrDados sdados = GameObject.FindGameObjectWithTag("scripts").GetComponent<ScrDados>();

        if (btitan) btitan.interactable = true;
        if (benemy) benemy.interactable = true;
        if (benemy1) benemy1.interactable = true;
        bSword.interactable = false;

        encasa = false;
        atacar = true;
        primerturno = true;
        sdados.Tirar4dados();
    }	     
    

    private void Destruccion()
    {
        ScrVida cartas = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ScrVida>(); // Para acceder a la vida del enemy
        ScrVida vidaplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ScrVida>();

        if (cartas.name == "Titan" && cartas.vidaNPC <= 0)
        {
            TitanDie.Play();
            Destroy(Titan);
            todosmuertos--;
        }

        if (cartas.name == "Enemigo1" && cartas.vidaNPC <= 0)
        {
            Priest1Die.Play();
            Destroy(Enemy);
            todosmuertos--;
        }

        if (cartas.name == "Enemigo2" && cartas.vidaNPC <= 0)
        {
            Priest2Die.Play();
            Destroy(Enemy1);
            todosmuertos--;
        }

        if (todosmuertos == 0)
        {
            ScrCtrlBatalla.Partida_Win();
        }

        if (vidaplayer.vidaPlayer <= 0)
        {
            ScrCtrlBatalla.Partida_Gover();
        }


    }
}

