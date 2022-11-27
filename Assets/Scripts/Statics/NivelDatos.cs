using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NivelDatos : MonoBehaviour {
    
    public static int playerHP;
    public static int oroDisponible;
    public static int numeroEnemigosRestantes=0;
    public static bool onHUD;
    public static Transform lugarDeConstruccion;
    public static string torreAInstancear;
    protected int NumeroTorres;
    protected int NumeroTorresRestantes;
    protected int numeroEnemigos;
    protected int valorCombateEnemigos;
    protected int enemigosRestantes;
    protected int enemigosPosibles;
    public GameObject enemigos;
    public GameObject torres;
    static public List<GameObject> monstruos = new List<GameObject>();
    static public List<GameObject> torresDisponibles = new List<GameObject>();
    static public List<GameObject> botones = new List<GameObject>();

    protected void Ronda(){
        if (valorCombateEnemigos>=0){
            StartCoroutine(SpawnEnemigos());
        } else {
        }
    }

    protected IEnumerator SpawnEnemigos(){
        for (int i=0; i<=valorCombateEnemigos;){
            Invoke("InstanceEnemigos", 0f);
            numeroEnemigosRestantes += 1;
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

    protected void CargarTorres(Image interfaceUser, GameObject boton){
        foreach (GameObject torres in torresDisponibles){
            GameObject botonGenerado = Instantiate(boton, interfaceUser.transform, interfaceUser.transform);
            botonGenerado.GetComponentInChildren<TextMeshProUGUI>().text = torres.name;
            if (!botonGenerado.GetComponent<TipoDeTorre>()){
                botonGenerado.AddComponent<TipoDeTorre>();
            }
            botones.Add(botonGenerado);


            botonGenerado.GetComponent<Button>().onClick.AddListener(InstancearTorres);
        }
    }

    protected void InstancearTorres(){
        foreach (GameObject boton in botones){
            boton.GetComponent<TipoDeTorre>().Tipo(boton);
        }
        foreach (GameObject torres in torresDisponibles){
            if (torres.name == torreAInstancear){
                Instantiate(torres, lugarDeConstruccion.position, new Quaternion(0f,0f,0f,0f), torres.transform);
            }
        }
    }



    protected void GameOver(){
        if (playerHP<=0){
            Debug.Log("Game Over");
        }
    }
    
                      //----------------------------------------------------- //
                      //----------------------------------------------------- //
                                // RELACIONADO A LA INTERFACE - HUD //
                      //----------------------------------------------------- //
                      //----------------------------------------------------- //

    protected void HUD(GameObject interfaceUser, GameObject panelDeTorres){
        if (onHUD) {
            onHUD = true;
            panelDeTorres.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape) || !onHUD) {
            onHUD=false;
            panelDeTorres.SetActive(false);
        }

        foreach (TextMeshProUGUI tmp in interfaceUser.GetComponentsInChildren<TextMeshProUGUI>()){

            if (tmp.name == "EnemigosRestantes"){
                tmp.text = "Enemigos Restantes: " + numeroEnemigosRestantes;
            }
            if (tmp.name == "Ronda"){
                tmp.text = "Ronda N° 1";
            }
            if (tmp.name == "HPPlayer"){
                tmp.text = "HP Restante: " + playerHP;
            }
            if (tmp.name == "OroDisponible"){
                tmp.text = "Oro: " + oroDisponible;
            }
        }
    }

                      //----------------------------------------------------- //
                      //----------------------------------------------------- //
                    // TODO LO DE ABAJO SON ESTADISTICAS Y VALORES DE LAS COSAS //
                      //----------------------------------------------------- //
                      //----------------------------------------------------- //


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
                oroDisponible = 5;
                NumeroTorres = 5;
                numeroEnemigos = 50;
                valorCombateEnemigos = 30;
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

    protected int Coste(GameObject torre, int oroDisponible){
        switch (torre.name){
            case "Mago Fuego":
                oroDisponible -= 1;
                break;
            case "Snake":
                oroDisponible -= 2;
                break;
            case "Unicorn":
                oroDisponible -= 3;
                break;
            case "Bear":
                oroDisponible -= 5;
                break;
            case "Ent":
                oroDisponible -= 5;
                break;
            case "Golem":
                oroDisponible -= 7;
                break;
            case "Griffin":
                oroDisponible -= 7;
                break;
            case "Dragon":
                oroDisponible -= 10;
                break;
        }
        return oroDisponible;
    }

}