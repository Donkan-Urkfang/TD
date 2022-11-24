using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel1PathB : MonoBehaviour {
    public static Transform []caminoB;

    private void Awake() {
        caminoB = gameObject.GetComponentsInChildren<Transform>();
    }
}