using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // per a usar qualssevol sistema relacionat amb UI
using Fungus; // per a trucar qualssevol funció a través de Fungus

/// <summary>
/// ---------------------------------------------
/// ---------SCR INVENTORY-----------------------
/// Gestió de l'inventari
/// 
/// Versió 0.2
/// Carlos Serrano
/// Data 14-04-19
///     0.1 primera versió
///     0.2 implantació de la interfície
///
/// ---------------------------------------------
/// </summary>

public class ScrInventory : MonoBehaviour {

    public Flowchart Flow_game; //L'esquema del Fungus dins del nivell
    public GameObject Inventory; //L'inventari
    public Canvas[] UI; // El Canvas en la qual són la resta de la UI
    public Text[] UI_Inv_Num; // Posar la quantitat de l'ítem
    public Button[] UI_Inv_Btn; // Els botons que usarem dins dels ítems
    public Button[] UI_Actions; // (Només per a la batalla) Botons d'interacció per el combat
    public AudioSource snd_Bag; // Àudio quan obre la motxilla
    bool activated = false;

	// Update is called once per frame
	void Update () {

        // ************* ACTUALITZACIÓ TEXTS **************************

        for (int i = 0; i < 8; i++)
        {
            UI_Inv_Num[i].text = ScrCtrlGame.pointItem[i].ToString();

            if (ScrCtrlGame.pointItem[i] > 0) UI_Inv_Btn[i].interactable = true;
            else UI_Inv_Btn[i].interactable = false;

            if (i > 1) // Canvi o establiment de color a les caselles de les ARMES
            {
                if (!ScrCtrlGame.activated_army[i-2])
                {
                    UI_Inv_Num[i].color = Color.yellow;
                }

                else
                {
                    UI_Inv_Num[i].color = Color.green;
                }
            }

        }

        // ************* INPUTS I FUNCIONS BÀSIQUES *******************
		
        if (Input.GetKeyDown(KeyCode.E) && !ScrCtrlFungus.in_Speech)
        {
            btn_Inventory();

        }



    }

    // ************* FUNCIONS BÀSIQUES DELS BOTONS *******************

    public void btn_Item1()
    {
        ScrCtrlGame.pointItem[0]--;
        ScrCtrlGame.Pers_HP += 25;
        if (ScrCtrlGame.Pers_HP > ScrCtrlGame.Pers_HP_max) ScrCtrlGame.Pers_HP = ScrCtrlGame.Pers_HP_max;
        Flow_game.SetIntegerVariable("Player_vitality", ScrCtrlGame.Pers_HP);
        Flow_game.SetIntegerVariable("item_Fruit", ScrCtrlGame.pointItem[0]);
    }

    public void btn_Item2()
    {
        ScrCtrlGame.pointItem[1]--;
        ScrCtrlGame.Pers_HP = ScrCtrlGame.Pers_HP_max;
        Flow_game.SetIntegerVariable("Player_vitality", ScrCtrlGame.Pers_HP);
        Flow_game.SetIntegerVariable("item_bag", ScrCtrlGame.pointItem[1]);
    }

    public void btn_ItemArmy(int A)
    {

        if (!ScrCtrlGame.activated_army[A])
            ScrCtrlGame.activated_army[A] = true;

        else
            ScrCtrlGame.activated_army[A] = false;
    }

    public void btn_Inventory()
    {
        activated = !activated;
        Inventory.SetActive(activated);
        ScrCtrlGame.EstaInventari = activated;
        snd_Bag.Play();

        if (UI[0])
        {
            for (int i = 0; i < UI.LongLength; i++)  // El LongLength és vàlid quan tenim objectes que no depenen de l'script
            {
                if (UI[0]) UI[i].enabled = !activated;

            }
        }

        if (!UI_Actions[0]) return; //Quan no estiguem en mode combat

        for (int i = 0; i < UI_Actions.LongLength; i++)
        {
            UI_Actions[i].interactable = !activated;
        }
    }

}
