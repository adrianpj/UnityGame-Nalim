using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

/// <summary>
/// ---------------------------------------------
/// ---------SCR FUNGUS PLAYER-------------------
/// Gestió del control del PLAYER dins de FUNGUS
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 16-02-19
/// ---------------------------------------------
/// </summary>

public class ScrFungus_Player : MonoBehaviour {

    public Flowchart Fungus_Scene;
	
    //Inicialització variables
	void Start () {

        Fungus_Scene.SetIntegerVariable("valXPPlayer", ScrCtrlGame.XP_Point);
        Fungus_Scene.SetIntegerVariable("valXPrestant", ScrCtrlGame.XP_Next);
        Fungus_Scene.SetIntegerVariable("Player_vitality", ScrCtrlGame.Pers_HP);
        Fungus_Scene.SetIntegerVariable("Player_vitalityMAX", ScrCtrlGame.Pers_HP_max);
        Fungus_Scene.SetIntegerVariable("valPerception", ScrCtrlGame.pointStatistic[2]);
        Fungus_Scene.SetIntegerVariable("valMagic", ScrCtrlGame.pointSkill[7]);
        Fungus_Scene.SetIntegerVariable("item_Fruit", ScrCtrlGame.pointItem[0]);
        Fungus_Scene.SetIntegerVariable("item_bag", ScrCtrlGame.pointItem[1]);
    }

    void Update()
    {
        //Actualitza les components del Flowchart a les variables
        ScrCtrlGame.XP_Point = Fungus_Scene.GetIntegerVariable("valXP");
        ScrCtrlGame.Pers_HP = Fungus_Scene.GetIntegerVariable("Player_vitality");

        //Actualitza els ítems del JUGADOR
        ScrCtrlGame.pointItem[0] = Fungus_Scene.GetIntegerVariable("item_Fruit"); // Fruites màgiques
        ScrCtrlGame.pointItem[1] = Fungus_Scene.GetIntegerVariable("item_bag"); // Bossa d'aliments
        ScrCtrlGame.pointItem[2] = Fungus_Scene.GetIntegerVariable("item_arc"); // Arc
        ScrCtrlGame.pointItem[3] = Fungus_Scene.GetIntegerVariable("item_Dagger"); // Espassa / daga de Barda
        ScrCtrlGame.pointItem[4] = Fungus_Scene.GetIntegerVariable("item_cane"); // Bastó de Nila
        ScrCtrlGame.pointItem[5] = Fungus_Scene.GetIntegerVariable("item_axe"); // Destral

        //Actualitza el booleà SUPORT AL COMBAT FINAL
        ScrCtrlGame.ToHelpBattle = Fungus_Scene.GetBooleanVariable("talked_toHelp");

        if (ScrCtrlGame.numMascara == 0) Fungus_Scene.SetBooleanVariable("Player_mask_sp1", true);
        else Fungus_Scene.SetBooleanVariable("Player_mask_sp1", false);
    }
}
