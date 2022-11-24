using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel1 : NivelDatos {

    public GameObject spider;
    public GameObject snake;

    public void Awake() {
        Datos(gameObject.name);
        monstruos.Add(spider);
        monstruos.Add(snake);
    }
    private void Start() {
        StartCoroutine(SpawnEnemigos());
    }   
}