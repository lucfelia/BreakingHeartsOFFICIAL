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


    // Start is called before the first frame update
    void Start()
    {
        //encuentre a scoreui en unity y saque lo que tiene escrito
        text = GameObject.Find("ScoreUI").GetComponent<TextMeshProUGUI>();
        Enemigo = GameObject.Find("Enemigo");
        if (Enemigo != null) { EnemyLife = Enemigo.GetComponent<EnemyLife>(); }
    }

    // Update is called once per frame
    void Update()
    {
        if (score <= 0) { score = 0; }
        if (score % 20 == 0 && score != lastdano)
        {
            Debug.Log("Enemigo ouch");
            Debug.Log(lastdano);
            EnemyLife.TomarDañoEnemigo(dano);
            lastdano = score;
        }
        text.text = "Score: " + score.ToString();
    }
}
