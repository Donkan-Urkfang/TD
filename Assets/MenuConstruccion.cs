using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuConstruccion : MonoBehaviour
{
    private void Update() {
        Desactivar();
    }


    private void OnMouseDown() {
        Nivel1.onHUD = true;
        Nivel1.lugarDeConstruccion = this.transform;
        gameObject.GetComponent<Animator>().SetBool("estaSeleccionada", true);

    }

    void Desactivar(){
        if (Nivel1.onHUD == false){
            gameObject.GetComponent<Animator>().SetBool("estaSeleccionada", false);
        }
    }

}
