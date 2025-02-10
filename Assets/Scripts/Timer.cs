using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timer = 0f;
    private bool generatorOff = false;

    public float timeStop = 10f;
    public float timeMenu = 12.5f;

    public GameObject menuInicial;
    public GameObject generador;
    public GameObject menuGameplay;
    public EventSystem eventSystem;
    public GameObject botonAttack;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= timeStop && !generatorOff)
        {
            Debug.Log("generador false");
            generador.SetActive(false);
            generatorOff = true;
        }
        if (timer >= timeMenu)
        {
            Debug.Log("volver a menu ataque");
            menuInicial.SetActive(true);
            eventSystem.SetSelectedGameObject(botonAttack);
            generador.SetActive(true);
            menuGameplay.SetActive(false);
            timer = 0f;
            generatorOff = false;
        }
        timer += Time.deltaTime;
    }
}
