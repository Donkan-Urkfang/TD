using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipoDeTorre : MonoBehaviour
{
    public void Tipo(GameObject boton){
        if (boton.GetComponentInChildren<TextMeshProUGUI>().text == gameObject.GetComponentInChildren<TextMeshProUGUI>().text){
            NivelDatos.torreAInstancear = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        }
    }
}
