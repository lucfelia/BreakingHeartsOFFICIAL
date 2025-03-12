using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timer = 0f;
    private float healed = 0f;
    public GameObject enemy;
    public float timeEnemy = 1.5f;
    public float timeStop = 10f;
    public float timeMenu = 12.5f;
    public float timeHeal = 5f;

    private GameObject canvas;
    private MenuManager menuManager;

    public GameObject generadorLofi;
    public GameObject generadorNightCore;
    public GameObject menuGameplay;
    public EventSystem eventSystem;
    public VidaJugador vidaJugador;

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
        if (menuManager.playingClassic) {
            if (timer >= timeStop) {
                generadorLofi.SetActive(false);
            }
            if (timer >= timeMenu) {
                timer = 0f;
                menuManager.AbrirMenuContraataque();
                generadorLofi.SetActive(true);
            }
            timer += Time.deltaTime;
        }
        if (menuManager.playingNightcore) {
            if (timer >= timeStop) { generadorNightCore.SetActive(false); }
            if (timer >= timeMenu) {
                timer = 0f;
                menuManager.AbrirMenuContraataque();
                generadorNightCore.SetActive(true);
            }
            timer += Time.deltaTime;
        }
        if (menuManager.playingReggaeton)
        {
            //if (timer >= timeStop) {  }
            if (timer >= timeMenu)
            {
                timer = 0f;
                menuManager.AbrirMenuContraataque();                
            }
            timer += Time.deltaTime;
        }
        if (menuManager.curarGameplay.activeSelf) {          
            if (timer >= timeHeal) {                
                timer = 0f;
                menuManager.AbrirMenuContraataque();   
            }
            if (vidaJugador.vidaActual == vidaJugador.vidaMax) {
                timer = 0f;
                healed += Time.deltaTime;
                if (healed >= timeEnemy) {
                    Debug.Log("Healed timer off");
                    timer = 0f; 
                    healed = 0f; 
                    menuManager.AbrirMenuContraataque(); 
                }
            }
            timer += Time.deltaTime;
        }
    }
}
