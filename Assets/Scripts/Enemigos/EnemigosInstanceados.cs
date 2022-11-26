using UnityEngine;

public class EnemigosInstanceados : Enemigos
{
    private void Awake() {
        Tipo(this.name);
        CaminoAleatorio();
    }

    void Update() {
        Path();
        Animation();
        HpRestanteHUD();
        PosicionEnemyHUD();
    }
}
