using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreDisparo : MonoBehaviour
{
    public float atk;
    public Transform enemigoApuntado;
    private bool enemigoGolpeado;
    private GameObject go;
    float speed = 5f;

    void TargetDisparo(){
        if (enemigoApuntado == null && enemigoGolpeado == false){
            this.tag = "Untagged";
            Death(0f);
        } else {
            if (enemigoGolpeado){
                this.tag = "Untagged";
                transform.position = Vector3.MoveTowards(transform.position, enemigoApuntado.position, speed * Time.deltaTime);
            } else {
                transform.position = Vector3.MoveTowards(transform.position, enemigoApuntado.position, speed * Time.deltaTime); 
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(enemigoApuntado.transform.position - transform.position), 1f);
            }
        }
    }

    void Update()
    {
        TargetDisparo(); 
    }

    private void OnTriggerEnter(Collider other) {
        enemigoGolpeado = true;
        enemigoApuntado.transform.GetComponent<EnemigosInstanceados>().DañoRecibidoVirtual(atk);
        Death(0.15f);
    }

    private void Death(float tiempo){
        go = this.gameObject;
        Destroy(gameObject,tiempo);

    }
}
