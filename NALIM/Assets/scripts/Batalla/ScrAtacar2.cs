using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrAtacar2 : MonoBehaviour {

    /// <summary>
    /// ---------------------------------------------
    /// ---------SCR ATACAR2-------------------------
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
    public bool targetPlayer = false,  targetNila = false, targetJack = false;
    public bool titanEnemy; //Si el Titan por supuesto se caracterizara como enemigo
    public Button bNila, bJack, bSword, bInventory, bDefense;
    public GameObject Nila, Jack, Player;
    public AudioSource NilaDie, JackDie; //Los audiosources de la muerte de los enemigos

    public Sprite[] Sprites;
    public Image[] Spr_Enemy;

    // Controlar donde está el Player y si ha atacado
    bool encasa = true; //Si es true es que no ataca o ya ha acabado su turno
    bool atacar = false; //Saber si el player ha atacado 
    bool primerturno = false; //El Player ataca primero

    public int todosmuertos = 2; //Para saber si han muerto Nila y/o Jack

    //AudioSource
    public AudioSource PlayerDamage;
    public AudioSource[] SndEnemyAttack;

    void Start()
    {
        bNila.interactable = false;
        bJack.interactable = false;
    }

    void Update()
    {
        if (!ScrCtrlBatalla.BattleFinalised)
        {

            ScrDados sdados = GameObject.FindGameObjectWithTag("scripts").GetComponent<ScrDados>(); // Para acceder al script Scr_Dados
            ScrDaño sdañoP = GameObject.FindGameObjectWithTag("Player").GetComponent<ScrDaño>(); // Para acceder al daño que tiene el player
            ScrDaño sdañoB = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ScrDaño>(); // Para acceder al daño que tiene Nila y Jack
            ScrVida cartaplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ScrVida>(); // Para acceder a la vida del player
            ScrVida cartas = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ScrVida>(); // Para acceder a la vida de Nila y Jack

            //   ---------------------------------------------------------------------
            //   ---------------- Para saber a quien ha atacado el Player --------------
            //   ---------------------------------------------------------------------

            if ((targetNila || targetJack) && !encasa)
            {
                if (ScrCtrlBatalla.crono > 1f && primerturno)
                {

                       cartas.vidaNPC -= sdañoP.dañoPlayer;

   
                    Destruccion();

                    if (atacar && !cartaplayer.immune)
                    {
                        Spr_Enemy[sdañoB.HojaSprite / 3].sprite = Sprites[2 + sdañoB.HojaSprite];
                        if (targetNila) SndEnemyAttack[0].Play();
                        if (targetJack) SndEnemyAttack[1].Play();
                    }

                    primerturno = false;

                }

                if (ScrCtrlBatalla.crono > 2f)
                {

                    if (targetNila) targetNila = false;
                    if (targetJack) targetJack = false;

                    bSword.interactable = true;
                    bInventory.interactable = true;

                    encasa = true;

                    if (atacar && !cartaplayer.immune)
                    {
                        cartaplayer.vidaPlayer -= sdañoB.dañoNPC;
                        Spr_Enemy[sdañoB.HojaSprite / 3].sprite = Sprites[0 + sdañoB.HojaSprite];
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

        if (Nila) bNila.interactable = true;
        if (Jack) bJack.interactable = true;
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

        if (cartas.name == "Nila" && cartas.vidaNPC <= 0)
        {
            NilaDie.Play();
            Destroy(Nila);
            todosmuertos--;
        }

        if (cartas.name == "Jack" && cartas.vidaNPC <= 0)
        {
            JackDie.Play();
            Destroy(Jack);
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

