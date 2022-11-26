using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorresColocadas : Torres
{
    private void Awake() {
        //Tipo(this.tag);
    }

    private void Update() {
        Target();
    }
}
