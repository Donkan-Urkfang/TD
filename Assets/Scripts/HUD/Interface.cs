using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public GameObject enemyHUD;
    public GameObject torresHUD;

    public void RecibeTransform(Transform enemy, float hpVirtual){
        Instantiate(enemyHUD, enemy.position, Camara.camaraJugador.rotation, enemy.transform);
    }


}
