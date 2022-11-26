using System.Collections.Generic;
using UnityEngine;

public class StartEnd : MonoBehaviour
{
    public List<Transform> lineasDeInicio;  
    public List<Transform> lineasDeFinal; 
    public static Transform []start;
    public static Transform []end;


    void LineaInicio(){
        foreach (Transform children in this.GetComponentsInChildren<Transform>()){
            if (children.CompareTag("Inicio")){
                lineasDeInicio.Add(children);
            } else if (children.CompareTag("Final")) {
                lineasDeFinal.Add(children);
            }
        }
        start = lineasDeInicio.ToArray();
        end = lineasDeFinal.ToArray();
        
    }

    private void Start() {
        LineaInicio();
    }
}
