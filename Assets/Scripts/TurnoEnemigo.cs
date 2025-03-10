using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;

public class TurnoEnemigo : MonoBehaviour
{
    public VidaJugador VidaJugador;
    private GameObject canvas;
    private MenuManager menuManager;
    public int dano_r; 
    public int dano;
    public bool ataco = false;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        if (canvas != null) menuManager = canvas.GetComponent<MenuManager>();


    }

    // Update is called once per frame
    void Update()
    {
        dano_r = Random.Range(232, 680);

        if (dano_r % 4 == 0)
        {
            dano = 2;
        }
        else if(dano_r % 9 == 0)
        {
            dano = 3;
        }
        else { dano = 1;}

        if (menuManager.playingContraataque) {
            if (!ataco)
            {
                Debug.Log("enemigo ataca");
                Debug.Log(dano_r);
                VidaJugador.TomarDaño(dano);
                ataco = true;
            }
        }
        if (menuManager.playingClassic || menuManager.curarGameplay.activeSelf)
        {
            ataco = false;
        }
        
    }
}
