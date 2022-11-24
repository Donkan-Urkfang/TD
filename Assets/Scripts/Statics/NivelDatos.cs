using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelDatos : MonoBehaviour {
    
    public static int playerHP;
    protected int NumeroTorres;
    protected int NumeroTorresRestantes;
    protected int numeroEnemigos;
    protected int numeroEnemigosRestantes;
    protected int valorCombateEnemigos;
    protected int valorCombateEnemigosUsado;
    protected int enemigosPosibles;
    public GameObject enemigos;
    public List<GameObject> monstruos = new List<GameObject>();


    protected IEnumerator SpawnEnemigos(){
        for (int i=valorCombateEnemigos; i>=0;){
            Invoke("InstanceEnemigos", 0f);
            yield return new WaitForSeconds(3f);
        }
    }

    protected void InstanceEnemigos(){
        GameObject monstruo = monstruos[Random.Range(0, monstruos.Count)];
        Instantiate(monstruo, StartEnd.start[0].position, StartEnd.start[0].rotation, enemigos.transform);
        ValorMonstruos(monstruo, valorCombateEnemigos);
    }

    protected void ValorMonstruos(GameObject monstruo, int a){
        switch (monstruo.tag){
            case "Spider":
                valorCombateEnemigos = a - 1;
                break;
            case "Snake":
                valorCombateEnemigos = a - 2;
                break;
            case "Unicorn":
                valorCombateEnemigos = a - 3;
                break;
            case "Bear":
                valorCombateEnemigos = a - 5;
                break;
            case "Ent":
                valorCombateEnemigos = a - 5;
                break;
            case "Golem":
                valorCombateEnemigos = a - 7;
                break;
            case "Griffin":
                valorCombateEnemigos = a - 7;
                break;
            case "Dragon":
                valorCombateEnemigos = a - 10;
                break;
        }
    }

    protected void Datos(string nivel){
        switch (nivel){
            case "Nivel1":
                playerHP = 10;
                NumeroTorres = 5;
                numeroEnemigos = 50;
                valorCombateEnemigos = 300;
                valorCombateEnemigosUsado = 0;
                enemigosPosibles = 1;
            break;

            case "Nivel2":

            break;

            case "Nivel3":

            break;

            case "Nivel4":

            break;

            case "Nivel5":

            break;
        }

    }
    
}