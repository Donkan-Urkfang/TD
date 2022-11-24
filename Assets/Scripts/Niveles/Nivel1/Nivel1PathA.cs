using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel1PathA : MonoBehaviour {
    public static Transform []caminoA;

    private void Awake() {
        caminoA = gameObject.GetComponentsInChildren<Transform>();
    }
}