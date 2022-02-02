using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ---------------------------------------------
/// ---------SCR MENU TIRADA---------------------
/// Gestió de la tirada dins del Main Menu
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 11-04-19
///     0.1 primera versió
///     
/// ---------------------------------------------
/// </summary>

public class ScrMenuTirada : MonoBehaviour {

    public AudioSource snd_tiradaDau3;

    bool tiradaprimera = false;
    int min;
    int suma;

    public void EfectuarTirada(int i)
    {
        if (ScrCtrlGame.LimitTirada[i] < 2)
        {
            snd_tiradaDau3.Play();

            ScrDados daus = new ScrDados();

            daus.Tirar4dados();
            min = Mathf.Min(daus.dado1, daus.dado2, daus.dado3, daus.dado4);
            suma = daus.dado1 + daus.dado2 + daus.dado3 + daus.dado4 - min;

            if (ScrCtrlGame.pointStatistic[i] <= suma)
            {
                ScrCtrlGame.pointStatistic[i] = suma; // Cada dels atributs

            }

            if (ScrCtrlGame.pointStatistic[0] > 0 && ScrCtrlGame.pointStatistic[1] > 0 && ScrCtrlGame.pointStatistic[2] > 0 && ScrCtrlGame.pointStatistic[3] > 0)
            {
                if (ScrCtrlGame.tiradaVida == false)
                {
                    ScrCtrlGame.Pers_HP =
                    ScrCtrlGame.pointStatistic[0] + ScrCtrlGame.pointStatistic[3] +
                    Random.Range(1, 7);

                    ScrCtrlGame.Pers_HP_max = ScrCtrlGame.Pers_HP;

                    ScrCtrlGame.tiradaVida = true;
                }

            }

            ScrCtrlGame.LimitTirada[i]++; //Suma del número de tirada
        }


    }

}
