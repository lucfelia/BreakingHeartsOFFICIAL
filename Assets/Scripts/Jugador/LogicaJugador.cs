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


    // Start is called before the first frame update
    void Start()
    {
        //encuentre a scoreui en unity y saque lo que tiene escrito
        text = GameObject.Find("ScoreUI").GetComponent<TextMeshProUGUI>();
        Enemigo = GameObject.Find("EnemyLogic");
        if (Enemigo != null) { EnemyLife = Enemigo.GetComponent<EnemyLife>(); }
    }

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
