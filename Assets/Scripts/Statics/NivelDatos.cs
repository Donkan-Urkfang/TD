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

    protected void Ronda(){
        if (valorCombateEnemigos>=0){
            StartCoroutine(SpawnEnemigos());
        } else {
        }
    }

    protected IEnumerator SpawnEnemigos(){
        for (int i=0; i<=valorCombateEnemigos;){
            Invoke("InstanceEnemigos", 0f);
            yield return new WaitForSeconds(3f);
        } 
    }

    protected void InstanceEnemigos(){
        GameObject monstruo = monstruos[Random.Range(0, monstruos.Count)];

        // Si un enemigo nuevo no tiene el script, se lo agrega automaticamente //
        if (!monstruo.GetComponent<EnemigosInstanceados>()){
            monstruo.AddComponent<EnemigosInstanceados>();
        }

        Instantiate(monstruo, StartEnd.start[0].position, StartEnd.start[0].rotation, enemigos.transform);
        valorCombateEnemigos = ValorMonstruos(monstruo, valorCombateEnemigos);
    }

    protected int ValorMonstruos(GameObject monstruo, int valorCombateEnemigos){
        switch (monstruo.name){
            case "Spider":
                valorCombateEnemigos -= 1;
                break;

            case "Snake":
                valorCombateEnemigos -= 2;
                break;

            case "Unicorn":
                valorCombateEnemigos -= 3;
                break;

            case "Bear":
                valorCombateEnemigos -= 5;
                break;

            case "Ent":
                valorCombateEnemigos -= 5;
                break;

            case "Golem":
                valorCombateEnemigos -= 7;
                break;

            case "Griffin":
                valorCombateEnemigos -= 7;
                break;

            case "Dragon":
                valorCombateEnemigos -= 10;
                break;
        }
        return valorCombateEnemigos;
    }

    protected void Datos(string nivel){
        switch (nivel){
            case "Nivel1":
                playerHP = 10;
                NumeroTorres = 5;
                numeroEnemigos = 50;
                valorCombateEnemigos = 6;
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

    protected void GameOver(){
        if (playerHP<=0){
            Debug.Log("Game Over");
        }
    }
    
}