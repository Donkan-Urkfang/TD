public class TipoEnemigo : Enemigos
{

    private void Awake() {
        Tipo(this.tag);
        CaminoAleatorio();
    }
    void Tipo(string tipo){
        switch (tipo){
            case "Spider":
                atk = 3;
                speed = 1;
                hp = 3;
                break;
            case "Snake":
                atk = 3;
                speed = 1;
                hp = 3;
                break;
            case "Unicorn":
                atk = 3;
                speed = 1;
                hp = 3;
                break;
            case "Bear":
                atk = 3;
                speed = 1;
                hp = 3;
                break;
            case "Ent":
                atk = 3;
                speed = 1;
                hp = 3;
                break;
            case "Golem":
                atk = 3;
                speed = 1;
                hp = 3;
                break;
            case "Griffin":
                atk = 3;
                speed = 1;
                hp = 3;
                break;
            case "Dragon":
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
