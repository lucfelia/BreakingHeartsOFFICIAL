using TMPro;
using UnityEngine;

public class LogicaJugador : MonoBehaviour
{
    public int dano = 1;
    private int lastdano = 0;

    public int score = 0;
    public TextMeshProUGUI text;

    public GameObject Enemigo;
    public EnemyLife EnemyLife;

    private int damageDone = 0;

    // Update is called once per frame
    void Update()
    {
        if (score <= 0) { score = 0; }
        if(score/40 > damageDone){
            Debug.Log("Enemigo ouch");
            Debug.Log(lastdano);
            EnemyLife.TomarDañoEnemigo(dano);
            lastdano = score;
            damageDone += dano;
        }
        text.text = "Score: " + score.ToString();
    }
}
