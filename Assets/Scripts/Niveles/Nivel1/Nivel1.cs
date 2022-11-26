using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel1 : NivelDatos {

    public GameObject spider;
    public GameObject unicorn;
    public GameObject bear;
    public GameObject dragon;
    public GameObject ent;
    public GameObject golem;
    public GameObject griffin;

    public void Awake() {
        Datos(gameObject.name);
        monstruos.Add(spider);
        monstruos.Add(unicorn);
        monstruos.Add(bear);
        monstruos.Add(dragon);
        monstruos.Add(ent);
        monstruos.Add(golem);
        monstruos.Add(griffin);
    }
    private void Start() {
        Ronda();
    }   
}