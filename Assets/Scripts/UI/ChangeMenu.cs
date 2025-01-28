using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeMenu : MonoBehaviour
{
    public GameObject menuInicial;
    public GameObject menuBeats;
    public GameObject menuGameplay;
    public EventSystem eventSystem;
    public GameObject botonOptions;
    public GameObject botonAttack;

    public void AbrirMenuInicial()
    {
        menuInicial.SetActive(true);
        menuBeats.SetActive(false);
        menuGameplay.SetActive(false);
        eventSystem.SetSelectedGameObject(botonAttack);
    }
    public void AbrirMenuBeats()
    {
        menuInicial.SetActive(false);
        menuBeats.SetActive(true);
        menuGameplay.SetActive(false);
        eventSystem.SetSelectedGameObject(botonOptions);
    }
    public void AbrirMenuGameplay()
    {
        menuInicial.SetActive(false);
        menuBeats.SetActive(false);
        menuGameplay.SetActive(true);
    }
}
