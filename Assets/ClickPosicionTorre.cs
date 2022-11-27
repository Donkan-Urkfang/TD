using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPosicionTorre : MonoBehaviour
{
    private void OnMouseDown() {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            if (!gameObject.GetComponent<Interface>()){
            gameObject.AddComponent<Interface>();
            
        } else {
            
        }

        }
        
    }
}
