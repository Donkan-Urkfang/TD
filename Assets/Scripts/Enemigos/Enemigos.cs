using UnityEngine;
using UnityEngine.UI;

public class Enemigos : MonoBehaviour
{
    protected Transform []caminoASeguir;
    protected Transform []caminoASeguirA = Nivel1PathA.caminoA;
    protected Transform []caminoASeguirB = Nivel1PathB.caminoB;
    protected Transform []caminoASeguirC = Nivel1PathC.caminoC;
    protected float atk;
    protected float speed;
    protected float hpVirtual;
    protected float hpVirtualTotal;
    protected int waypoint = 1;
    public float hpReal;
    
    protected void CaminoAleatorio(){
        switch (Random.Range(1,4)){
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
        if (hpVirtual>0){
            transform.position = Vector3.MoveTowards(transform.position, caminoASeguir[waypoint].position, speed * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, caminoASeguir[waypoint].position);
            if (!caminoASeguir[waypoint].CompareTag("Final")){
                if (distance <= 0.3f){
                        waypoint ++;
                }
            }
            if ((caminoASeguir[waypoint].position - transform.position) != Vector3.zero){
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(caminoASeguir[waypoint].position - transform.position), 0.1f);
            }
        }
    }

    protected void Tipo(string tipo){
        switch (tipo){
            case "Spider(Clone)":
                atk = 1f;
                speed = 2f;
                hpReal = 5f;
                break;
            case "Snake(Clone)":
                atk = 3f;
                speed = 1f;
                hpReal = 3f;
                break;
            case "Unicorn(Clone)":
                atk = 3f;
                speed = 5f;
                hpReal = 10f;
                break;
            case "Bear(Clone)":
                atk = 5f;
                speed = 1.5f;
                hpReal = 10f;
                hpVirtual = 10f;
                hpVirtualTotal = 10f;
                break;
            case "Ent(Clone)":
                atk = 5f;
                speed = 0.5f;
                hpReal = 25f;
                break;
            case "Golem(Clone)":
                atk = 5f;
                speed = 0.75f;
                hpReal = 50;
                break;
            case "Griffin(Clone)":
                atk = 10f;
                speed = 4f;
                hpReal = 10f;
                break;
            case "Dragon(Clone)":
                atk = 20f;
                speed = 5f;
                hpReal = 50f;
                break;
        }
    }

    protected void Animation(){
        if (speed != 0 && hpVirtual>0)
        {
            gameObject.GetComponentInChildren<Animator>().SetBool("walk", true);
        } else {
            gameObject.GetComponentInChildren<Animator>().SetBool("walk", false);            
        }
        if (hpReal <= 0){
            gameObject.layer = 0;
        }
        if (hpVirtual <= 0){
            Death();
        }
    }

    protected void Death(){
        Destroy(gameObject.GetComponentInChildren<MeshCollider>());
        gameObject.GetComponentInChildren<Animator>().SetBool("death", true);
        Destroy(gameObject,2);
    }



    public void DañoRecibidoReal(float daño){
        hpReal = hpReal - daño;
    }  
    public void DañoRecibidoVirtual(float daño){
        hpVirtual = hpVirtual - daño;
    }  

    protected void IniciarHUD(GameObject hud){
        Instantiate(hud, this.transform.position, Camara.camaraJugador.rotation, this.transform);
    }

    protected void HpRestanteHUD(){
        this.GetComponentInChildren<Slider>().value = hpVirtual/hpVirtualTotal;
        
    }
    protected void PosicionEnemyHUD(){
        this.GetComponentInChildren<Slider>().transform.rotation = Camara.camaraJugador.rotation;
    }

    protected void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Final")){
            Death();
            NivelDatos.playerHP -= 1;
        }
    }
}

