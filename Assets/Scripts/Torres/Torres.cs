using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torres : MonoBehaviour
{
    protected float basicAtk = 1f;
    protected float rangeAtk = 10f;
    protected float speedAtk = 1f;
    protected float speedAtkTemp = 1f;
    protected float hp = 1f;
    protected GameObject disparo;
    //protected int speed;
    protected bool alert;
    protected LayerMask Enemy;
    protected Transform []posEnemy;
    protected Transform enemigos1;
    protected bool cooldown;
    public Transform salidaDisparo;
    public GameObject []cargaDisparos;
    public Transform balasInstanceadas; 
    public TorreDisparo scriptDisparo;
    private Transform enemigoAtacado;
    
    protected void Target(){
        alert = Physics.CheckSphere(transform.position,rangeAtk, LayerMask.GetMask("Enemy"));
        if (alert){
            Raycast();  
        }
    }

    protected void Raycast(){
        RaycastHit[] hitSphere;
            hitSphere = Physics.SphereCastAll(this.transform.position, rangeAtk, transform.forward, rangeAtk,LayerMask.GetMask("Enemy"));


            enemigoAtacado = EnemigoCercano(hitSphere, hitSphere[0].transform);


            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(enemigoAtacado.position - transform.position), 0.1f);

            
            if (!cooldown && enemigoAtacado.GetComponent<EnemigosInstanceados>().hpReal>0){

                disparo = cargaDisparos[0]; //CAMBIAR MAS ADELANTE

                scriptDisparo.enemigoApuntado = enemigoAtacado;

                scriptDisparo.atk = basicAtk;

                enemigoAtacado.transform.GetComponent<EnemigosInstanceados>().DañoRecibidoReal(basicAtk);

                Instantiate(disparo, salidaDisparo.transform.position, transform.rotation, balasInstanceadas);
                cooldown=true;

            } else {
                speedAtkTemp -= 1f * Time.deltaTime;
            }
            if (speedAtkTemp <= 0){
                cooldown=false;
                speedAtkTemp = speedAtk;
            }


    }

    protected Transform EnemigoCercano(RaycastHit[] distancia, Transform b){
        for (int i = 0; i<distancia.Length; i++){
            Transform a = distancia[i].transform;
            if (Vector3.Distance(this.transform.position, a.position) <= Vector3.Distance(this.transform.position, b.position)){
                b = distancia[i].transform;
            }
        }
        return b;
    }
    
    protected void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeAtk);
    }

    protected void Tipo(string tipo){
        switch (tipo){
            case "Wizard":
                basicAtk = 1;
                //speed = 0;
                hp = 3;
                disparo = cargaDisparos[0];
                break;
        }
    }

    /* protected IEnumerator Attack(float speedAtk){
        Target();
        yield return new WaitForSeconds(speedAtk);
    } */

    /* protected void Animation(){
        if (speed != 0 && hp>0)
        {
            gameObject.GetComponentInChildren<Animator>().SetBool("walk", true);
        } else {
            gameObject.GetComponentInChildren<Animator>().SetBool("walk", false);            
        }
        if (hp <= 0){
            Death();
        }
    }

    protected void Death(){
        hp=0;
        Destroy(gameObject.GetComponent<Collider>());
        Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.GetComponentInChildren<Animator>().SetBool("death", true);
        Destroy(gameObject,5f);
    } */

}
