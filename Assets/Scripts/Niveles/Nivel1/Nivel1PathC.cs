using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel1PathC : MonoBehaviour {
    public static Transform []caminoC;

    private void Awake() {
        caminoC = gameObject.GetComponentsInChildren<Transform>();
    }
}