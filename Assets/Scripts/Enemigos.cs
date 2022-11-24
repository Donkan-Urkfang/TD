using UnityEngine;

public class Enemigos : MonoBehaviour
{
    protected Transform []caminoASeguir;
    protected Transform []caminoASeguirA = Nivel1PathA.caminoA;
    protected Transform []caminoASeguirB = Nivel1PathB.caminoB;
    protected Transform []caminoASeguirC = Nivel1PathC.caminoC;
    protected int atk;
    protected int speed;
    protected int hp;
    protected int waypoint = 1;
    
    protected void CaminoAleatorio(){
        switch (Random.Range(1,3)){
            case 1:
                caminoASeguir = caminoASeguirA; 
            break;

            case 2:
                caminoASeguir = caminoASeguirB; 
            break;

            case 3:
                caminoASeguir = caminoASeguirC; 
            break;
        }
    }

    protected void Path(){
        transform.position = Vector3.MoveTowards(transform.position, caminoASeguir[waypoint].position, speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, caminoASeguir[waypoint].position);
        if (distance <= 0.1f){
                waypoint ++;
        }
    }

    protected void Animation(){
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
    }

    protected void OnTriggerEnter(Collider other) {
        if (other.tag == "Final"){
            Death();
            NivelDatos.playerHP -= 1;
        }
    }    
}

