using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Nivel1 : NivelDatos {

    //Interface de Usuario

    public GameObject interfaceUser;
    public GameObject panelDeTorres;

    //Agrega Monstruos de este nivel

    public GameObject spider;
    public GameObject unicorn;
    public GameObject bear;
    public GameObject dragon;
    public GameObject ent;
    public GameObject golem;
    public GameObject griffin;

    //Agrega Torres disponibles de este nivel

    public GameObject torreDeFuego;
    public GameObject torreDeHielo;



    public GameObject botonTorre;



    public void Awake() {
        Datos(gameObject.name);
        monstruos.Add(spider);
        monstruos.Add(unicorn);
        monstruos.Add(bear);
        monstruos.Add(dragon);
        monstruos.Add(ent);
        monstruos.Add(golem);
        monstruos.Add(griffin);

        torresDisponibles.Add(torreDeFuego);
        torresDisponibles.Add(torreDeHielo);
    }
    private void Start() {
        Ronda();
        CargarTorres(interfaceUser.GetComponentInChildren<Image>(), botonTorre);
    }   

    private void Update() {
        HUD(interfaceUser, panelDeTorres);     
    }

    /* private void AgregaTorresDisponibles(){

        foreach (GameObject torre in torresDisponibles){
            Instantiate(botonTorre, this.transform, InterfaceUser.transform);
        }
    } */
}