using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ---------------------------------------------
/// ---------SCR TARGET--------------------------
/// Script para definir a qué enemigo se dirige
/// 
/// ---------------------------------------------
/// </summary>

public class ScrTarget : MonoBehaviour {

    public void Nila()
    {
        ScrCtrlBatalla.crono = 0f;
        ScrAtacar2 satacar2 = GetComponent<ScrAtacar2>();
        satacar2.bNila.interactable = false;

        satacar2.bInventory.interactable = false;
        satacar2.bDefense.interactable = false;

        satacar2.targetNila = true;
    }

    public void Barda()
    {
        ScrCtrlBatalla.crono = 0f;
        ScrAtacar satacar = GetComponent<ScrAtacar>();
        satacar.bBarda.interactable = false;

        satacar.bInventory.interactable = false;
        satacar.bDefense.interactable = false;

        satacar.targetBarda = true;

    }

    public void Titan1()
    {
        ScrCtrlBatalla.crono = 0f;
        ScrAtacar1 satacar1 = GetComponent<ScrAtacar1>();
        satacar1.btitan.interactable = false;

        satacar1.bInventory.interactable = false;
        satacar1.bDefense.interactable = false;

        satacar1.targetTitan = true;
    }

    public void Enemy()
    {
        ScrCtrlBatalla.crono = 0f;
        ScrAtacar satacar = GetComponent<ScrAtacar>();
        satacar.targetEnemy = true;

        satacar.bInventory.interactable = false;
        satacar.bDefense.interactable = false;

    }

    public void Enemy1()
    {
        ScrCtrlBatalla.crono = 0f;
        ScrAtacar1 satacar1 = GetComponent<ScrAtacar1>();
        satacar1.targetEnemy = true;

        satacar1.bInventory.interactable = false;
        satacar1.bDefense.interactable = false;

        satacar1.benemy.interactable = false;
    }

    public void Enemy1b()
    {
        ScrCtrlBatalla.crono = 0f;
        ScrAtacar1 satacar1 = GetComponent<ScrAtacar1>();
        satacar1.targetEnemy1 = true;
        satacar1.benemy1.interactable = false;

        satacar1.bInventory.interactable = false;
        satacar1.bDefense.interactable = false;

    }

    public void Jack()
    {
        ScrCtrlBatalla.crono = 0f;
        ScrAtacar2 satacar2 = GetComponent<ScrAtacar2>();
        satacar2.bJack.interactable = false;

        satacar2.bInventory.interactable = false;
        satacar2.bDefense.interactable = false;

        satacar2.targetJack = true;

    }

    public void Player()
    {
        ScrAtacar satacar = GetComponent<ScrAtacar>();
        satacar.targetPlayer = true;

    }

}
