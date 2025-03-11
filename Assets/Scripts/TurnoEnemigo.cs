using TMPro;
using UnityEngine;

public class TurnoEnemigo : MonoBehaviour
{
    public VidaJugador VidaJugador;
    private GameObject canvas;
    private MenuManager menuManager;
    public int dano_r; 
    public int dano;
    public bool ataco = false;
    public GameObject[] teclas;
    public GameObject Enemigo;
    public EnemyLife EnemyLife;
    private float timer = 0f;
    public float timeStop = 2f;
    int combocontra = 0;
    public TextMeshProUGUI enemytext;
    int randomKey;

    // Start is called before the first frame update
    void Start()
    {
        teclas[0].SetActive(false);
        teclas[1].SetActive(false);
        teclas[2].SetActive(false);
        teclas[3].SetActive(false);
        timer = 0f;
        randomKey = UnityEngine.Random.Range(0, teclas.Length);
        canvas = GameObject.Find("Canvas");
        if (canvas != null) menuManager = canvas.GetComponent<MenuManager>();

        Enemigo = GameObject.Find("EnemyLogic");
        if (Enemigo != null) EnemyLife = Enemigo.GetComponent<EnemyLife>();

    }

    // Update is called once per frame
    void Update()
    {
        if (menuManager.contraataque2Gameplay.activeSelf) { 
            enemytext.text = teclas[randomKey].ToString() + combocontra.ToString();
            
            if (teclas[randomKey] == teclas[0])
            {
                teclas[0].SetActive(true);
                teclas[0].transform.position = new Vector3(0, 0);
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    combocontra++;
                    Debug.Log(combocontra);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow)
                    || Input.GetKeyDown(KeyCode.RightArrow)
                    || Input.GetKeyDown(KeyCode.UpArrow)) { hurtRand(); }
            }
            else if (teclas[randomKey] == teclas[1])
            {
                teclas[1].SetActive(true);
                teclas[1].transform.position = new Vector3(0, 0);
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    combocontra++;
                    Debug.Log(combocontra);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow)
                    || Input.GetKeyDown(KeyCode.RightArrow)
                    || Input.GetKeyDown(KeyCode.UpArrow)) { hurtRand(); }
            }
            else if (teclas[randomKey] == teclas[2])
            {
                teclas[2].SetActive(true);
                teclas[2].transform.position = new Vector3(0, 0);
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    combocontra++;
                    Debug.Log(combocontra);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow)
                    || Input.GetKeyDown(KeyCode.DownArrow)
                    || Input.GetKeyDown(KeyCode.UpArrow)) { hurtRand(); }
            }
            else if (teclas[randomKey] == teclas[3])
            {
                teclas[3].SetActive(true);
                teclas[3].transform.position = new Vector3(0, 0);
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    combocontra++;
                    Debug.Log(combocontra);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow)
                    || Input.GetKeyDown(KeyCode.RightArrow)
                    || Input.GetKeyDown(KeyCode.DownArrow)) { hurtRand(); }
            }

            if (timer >= timeStop)
            {
                //Defensa
                if (combocontra >= 6 && combocontra <= 11)
                {
                    
                }
                //Contraataque
                else if (combocontra >= 12)
                {
                    dano = 1;
                    EnemyLife.TomarDañoEnemigo(dano);
                    ResetGameplay();
                }
                //RecibirDaño
                else if (combocontra <= 5)
                {
                    hurtRand();
                }
            }
            timer += Time.deltaTime;
        }
    }

    private void hurtRand()
    {
        dano_r = Random.Range(232, 680);
        if (dano_r % 4 == 0) dano = 2;
        else if (dano_r % 9 == 0) dano = 3;
        else dano = 1;
        Debug.Log("enemigo ataca");
        Debug.Log(dano_r);
        VidaJugador.TomarDaño(dano);
        ResetGameplay();
    }

    private void ResetGameplay()
    {
        timer = 0f;
        combocontra = 0;
        randomKey = UnityEngine.Random.Range(0, teclas.Length);
        teclas[0].SetActive(false);
        teclas[1].SetActive(false);
        teclas[2].SetActive(false);
        teclas[3].SetActive(false);
        menuManager.AbrirMenuInicial();
    }
}
