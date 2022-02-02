using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScrMostrarVidaPlayer : MonoBehaviour {

    float hp;
    public Text mivida;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScrVida lavida = GetComponent<ScrVida>();

        hp = lavida.vidaPlayer;
        mivida.text = hp.ToString();



    }
}
