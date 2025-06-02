using UnityEngine;
using UnityEngine.EventSystems;

public class Timer : MonoBehaviour
{
    public float timer = 0f;
    private float healed = 0f;
    public GameObject enemy;
    public float timeEnemy = 1.5f;
    public float timeStop = 10f;
    public float timeMenu = 12.5f;
    public float timeHeal = 5f;
    private float timeAviso = 3f;

    private GameObject canvas;
    private MenuManager menuManager;
    public GameObject menuGameplay;
    public EventSystem eventSystem;
    public VidaJugador vidaJugador;

    [Header("Lofi")]
    public GameObject generadorLofi;
    public Transform logicaContenedor;

    [Header("Nightcore")]
    public GameObject generadorNightcore;
    public Transform contenedorNightcore;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;

        canvas = GameObject.Find("Canvas");
        if (canvas != null) menuManager = canvas.GetComponent<MenuManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (menuManager.playingClassic)
        {
            if (timer >= timeStop)
            {
                generadorLofi.SetActive(false);
            }
            if (timer >= timeMenu)
            {
                timer = 0f;
                menuManager.AbrirMenuAviso();
                generadorLofi.SetActive(true);
            }
            timer += Time.deltaTime;
        }
        if (menuManager.playingNightcore)
        {
            if (timer >= timeStop) { generadorNightcore.SetActive(false); }
            if (timer >= timeMenu)
            {
                timer = 0f;
                menuManager.AbrirMenuAviso();
                generadorNightcore.SetActive(true);
            }
            timer += Time.deltaTime;
        }
        if (menuManager.playingReggaeton)
        {
            //if (timer >= timeStop) {  }
            if (timer >= timeMenu)
            {
                timer = 0f;
                menuManager.AbrirMenuAviso();
            }
            timer += Time.deltaTime;
        }
        if (menuManager.curarGameplay.activeSelf)
        {
            if (timer >= timeHeal)
            {
                timer = 0f;
                menuManager.AbrirMenuAviso();
            }
            if (vidaJugador.vidaActual == vidaJugador.vidaMax)
            {
                timer = 0f;
                healed += Time.deltaTime;
                if (healed >= timeEnemy)
                {
                    Debug.Log("Healed timer off");
                    timer = 0f;
                    healed = 0f;
                    menuManager.AbrirMenuAviso();
                }
            }
            timer += Time.deltaTime;
        }
        if (menuManager.warningContraataque.activeSelf)
        {
            //Limpia el lofi y el nightcore
            generadorLofi.SetActive(false);
            generadorNightcore.SetActive(false);
            foreach (Transform child in logicaContenedor) Destroy(child.gameObject);
            foreach (Transform child in contenedorNightcore) Destroy(child.gameObject);

            if (timer >= timeAviso)
            {
                generadorLofi.SetActive(true);
                generadorNightcore.SetActive(true);
                timer = 0f;
                menuManager.AbrirMenuContraataque();
            }
            timer += Time.deltaTime;
        }
    }
}