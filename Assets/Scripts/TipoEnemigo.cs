using UnityEngine;

public class TipoEnemigo : Enemigos
{
    private void Awake() {
        Tipo(this.tag);
    }
    void Tipo(string tipo){
        switch (tipo){
            case "Bear":
                atk = 3;
                speed = 1;
                hp = 3;
                break;
        }
    }

    void Update() {
        Path();
        Animation();
    }
}
