using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ---------------------------------------------
/// ---------SCR CURSOR--------------------------
/// Gestió del control del cursor
/// 
/// Versió 0.1
/// Carlos Serrano
/// Data 23-01-19
/// ---------------------------------------------
/// </summary>

public class ScrCursor : MonoBehaviour {

    //Declaració sensibilització
    public float sensitivity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //Ajusta la precisió del ratolí
        sensitivity = ScrCtrlGame.Adjsensitivity;
        Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse X") * sensitivity, Input.GetAxis("Mouse Y") * sensitivity);
    }
}
