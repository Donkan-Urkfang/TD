using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camara : MonoBehaviour 
{
    static public Transform camaraJugador;

    private void Awake() {
        camaraJugador = this.transform;
    }
}
