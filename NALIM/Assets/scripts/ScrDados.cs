using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ---------------------------------------------
/// ---------SCR DADOS---------------------------
/// Gestión para los dados
///
/// Versión 0.1
/// 
/// 09-05-19
///     0.1 primera versión
///
/// ---------------------------------------------
/// </summary>

public class ScrDados : MonoBehaviour {
        
    public int dado1, dado2, dado3, dado4; // Valores final que tiene el dado en cada tirada
    int suma; // Suma de todos los valores, menos el valor mas pequeño 

    //-----------------------------------
    // -------------- FUNCIONES ----------
    //--------------------------------------
   
    // Función para tirar dados y obtener los 4 valores de los atributos principales 

    public void Tirar4dados()
    {
        dado1 = Random.Range(1, 7);
        dado2 = Random.Range(1, 7);
        dado3 = Random.Range(1, 7);
        dado4 = Random.Range(1, 7);
    }

    public void SumarDados()
    {
        int minimo = Mathf.Min(dado1, dado2, dado3, dado4);

        suma = dado1 + dado2 + dado3 + dado4 - minimo;
    }    
}
