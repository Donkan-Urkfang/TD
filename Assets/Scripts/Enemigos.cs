using UnityEngine;
using UnityEngine.AI;

public class Enemigos : MonoBehaviour
{
    protected NavMeshAgent path;
    protected int atk;
    protected int speed;
    protected int hp;
    
    private void Start() {
        path = gameObject.GetComponent<NavMeshAgent>();
    }
    
    protected void Path(){
        if (path.enabled){
            path.SetDestination(StartEnd.end[0].position);
        }
    }

    protected void Animation(){
        if (path.speed != 0 && hp>0)
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
        Collider col = gameObject.GetComponentInChildren<Collider>();
        col.enabled = !col.enabled;
        path.enabled = !path.enabled;
        gameObject.GetComponentInChildren<Animator>().SetBool("death", true);
        Destroy(gameObject,5f);
    }

    protected void OnTriggerEnter(Collider other) {
        Death();
    }
}

