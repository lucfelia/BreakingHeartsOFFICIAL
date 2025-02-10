using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChangeMenu : MonoBehaviour
{
    public GameObject menuInicial;
    public GameObject menuBeats;
    public GameObject menuGameplay;
    public GameObject menuGameOver;
    public GameObject menuInstrucciones;
    public EventSystem eventSystem;
    public GameObject botonOptions;
    public GameObject botonAttack;

    public VidaJugador vidaJugador;
    public int curar = 1;

    public void AbrirMenuInicial()
    {
        menuInicial.SetActive(true);
        menuBeats.SetActive(false);
        menuGameplay.SetActive(false);
        menuGameOver.SetActive(false);
        menuInstrucciones.SetActive(true);
        eventSystem.SetSelectedGameObject(botonAttack);
    }
    public void AbrirMenuBeats()
    {
        menuInicial.SetActive(false);
        menuBeats.SetActive(true);
        menuGameplay.SetActive(false);
        menuGameOver.SetActive(false);
        menuInstrucciones.SetActive(true);
        eventSystem.SetSelectedGameObject(botonOptions);
    }
    public void AbrirMenuGameplay()
    {
        menuInicial.SetActive(false);
        menuBeats.SetActive(false);
        menuGameplay.SetActive(true);
        menuGameOver.SetActive(false);
        menuInstrucciones.SetActive(false);
    }
    public void GameOver()
    {
        menuInicial.SetActive(false);
        menuBeats.SetActive(false);
        menuGameplay.SetActive(false);
        menuGameOver.SetActive(true);
        menuInstrucciones.SetActive(false);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CurarJugador()
    {
        if (vidaJugador != null)
        {
            vidaJugador.CurarVida(curar);
        }
    }
}