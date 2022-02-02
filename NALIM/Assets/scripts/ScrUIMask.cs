using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ---------------------------------------------
/// ---------SCR UI MASK-------------------------
/// Gestió del control de la UI màscara
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 01-05-19
///     0.1 primera versió
/// ---------------------------------------------
/// </summary>

public class ScrUIMask : MonoBehaviour {

    public Image[] p_mask; //Les màscares que disposa el jugant
	
	void OnEnable () {

        for (int i = 0; i < 3; i++) p_mask[i].enabled = false;
        for (int i = 3; i > 0; i--) p_mask[i].enabled = false;
        p_mask[ScrCtrlGame.numMascara].enabled = true;

	}

}
