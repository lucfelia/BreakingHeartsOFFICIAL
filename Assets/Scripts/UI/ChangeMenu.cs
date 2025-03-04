using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChangeMenu : MonoBehaviour
{
    public GameObject menuInicial;
    public GameObject menuBeats;

    public GameObject menuGameplay;
    public GameObject menuPlayA;

    public GameObject menuGameOver;

    public GameObject menuInstrucciones;
    public GameObject menuEnemy;

    public EventSystem eventSystem;

    public GameObject botonOptions;
    public GameObject botonAttack;
    public GameObject botonRestart;

    public VidaJugador vidaJugador;
    public GameObject menuCuracion;
    public int curar = 1;
    public bool curado = false;

    public void AbrirMenuInicial()
    {
        Debug.Log("Cambio menu inicial");
        menuInicial.SetActive(true);
        menuBeats.SetActive(false);
        menuEnemy.SetActive(false);
        menuGameplay.SetActive(false);
        menuPlayA.SetActive(false);
        menuGameOver.SetActive(false);
        menuInstrucciones.SetActive(true);
        eventSystem.SetSelectedGameObject(botonAttack);
    }
    public void AbrirMenuBeats()
    {
        Debug.Log("Cambio menu beats");
        menuInicial.SetActive(false);
        menuBeats.SetActive(true);
        menuGameplay.SetActive(false);
        menuGameOver.SetActive(false);
        menuInstrucciones.SetActive(true);
        menuPlayA.SetActive(false);
        eventSystem.SetSelectedGameObject(botonOptions);
    }
    public void AbrirMenuGameplay()
    {
        Debug.Log("Cambio menu gameplay");
        menuInicial.SetActive(false);
        menuBeats.SetActive(false);
        menuGameplay.SetActive(true);
        menuPlayA.SetActive(true);
        menuGameOver.SetActive(false);
        menuInstrucciones.SetActive(false);
        curado = false;
    }
    public void EnemyTurn()
    {
        Debug.Log("Cambio menu enemigo");
        menuEnemy.SetActive(true);
        menuInicial.SetActive(false);
        menuBeats.SetActive(false);
        menuGameplay.SetActive(false);
        menuGameOver.SetActive(false);
        menuInstrucciones.SetActive(false);
        menuCuracion.SetActive(false);
    }
    public void GameOver()
    {
        Debug.Log("Cambio menu gameover");
        menuInicial.SetActive(false);
        menuBeats.SetActive(false);
        menuGameplay.SetActive(false);
        menuGameOver.SetActive(true);
        menuInstrucciones.SetActive(false);
        eventSystem.SetSelectedGameObject(botonRestart);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        Debug.Log("Juego reiniciado");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CurarJugador()
    {
        Debug.Log("Cambio menu");
        menuCuracion.SetActive(true);
        menuInicial.SetActive(false);
        menuBeats.SetActive(false);
        menuGameplay.SetActive(false);
        menuGameOver.SetActive(false);
        menuInstrucciones.SetActive(false);

    }
}