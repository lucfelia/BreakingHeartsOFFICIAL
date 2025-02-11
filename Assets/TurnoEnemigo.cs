using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;

public class TurnoEnemigo : MonoBehaviour
{
    public VidaJugador VidaJugador;
    public ChangeMenu ChangeMenu;
    public int dano_r; 
    public int dano;
    // Start is called before the first frame update
    void Start()
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

        Debug.Log("enemigo ataca");
        VidaJugador.TomarDaño(dano);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
