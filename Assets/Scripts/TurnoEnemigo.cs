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
    public TextMeshProUGUI contadorText;
    private float contadorSize;
    int combocontra = 0;
    int randomKey;

    // Start is called before the first frame update
    void Start()
    {
        contadorSize = contadorText.fontSize;

        teclas[0].SetActive(false);
        teclas[1].SetActive(false);
        teclas[2].SetActive(false);
        teclas[3].SetActive(false);
        contadorText.text = "";
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
        if (menuManager.playingContraataque) {

            contadorText.text = combocontra.ToString();
            //Defensa
            if (combocontra > 7 && combocontra < 10) contadorText.color = Color.Lerp(Color.white, new Color(1.5f, 0.25f, 0f), 1f); //naranja
            //Contraataque
            else if (combocontra >= 10) contadorText.color = Color.red;
            //RecibirDaño
            else if (combocontra <= 7) contadorText.color = Color.yellow;

            if (teclas[randomKey] == teclas[0])
            {
                teclas[0].SetActive(true);
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    combocontra++;
                    contadorText.fontSize = contadorText.fontSize + 25;
                    Debug.Log(combocontra);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow)
                    || Input.GetKeyDown(KeyCode.RightArrow)
                    || Input.GetKeyDown(KeyCode.UpArrow)) { hurtRand(); }
            }
            else if (teclas[randomKey] == teclas[1])
            {
                teclas[1].SetActive(true);
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    combocontra++;
                    contadorText.fontSize = contadorText.fontSize + 25;
                    Debug.Log(combocontra);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow)
                    || Input.GetKeyDown(KeyCode.RightArrow)
                    || Input.GetKeyDown(KeyCode.UpArrow)) { hurtRand(); }
            }
            else if (teclas[randomKey] == teclas[2])
            {
                teclas[2].SetActive(true);
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    combocontra++;
                    contadorText.fontSize = contadorText.fontSize + 25;
                    Debug.Log(combocontra);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow)
                    || Input.GetKeyDown(KeyCode.DownArrow)
                    || Input.GetKeyDown(KeyCode.UpArrow)) { hurtRand(); }
            }
            else if (teclas[randomKey] == teclas[3])
            {
                teclas[3].SetActive(true);
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    combocontra++;
                    contadorText.fontSize = contadorText.fontSize + 25;
                    Debug.Log(combocontra);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow)
                    || Input.GetKeyDown(KeyCode.RightArrow)
                    || Input.GetKeyDown(KeyCode.DownArrow)) { hurtRand(); }
            }

            if (timer >= timeStop)
            {
                //Defensa
                if (combocontra > 7 && combocontra < 10)
                {
                    contadorText.color = Color.Lerp(Color.white, new Color(1.5f,0.5f,0f),0.5f); //naranja
                    ResetGameplay();
                }
                //Contraataque
                else if (combocontra >= 10)
                {
                    contadorText.color = Color.red;
                    dano = 1;
                    EnemyLife.TomarDañoEnemigo(dano);
                    ResetGameplay();
                }
                //RecibirDaño
                else if (combocontra <= 7)
                {
                    contadorText.color = Color.yellow;
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
        contadorText.fontSize = contadorSize;
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
