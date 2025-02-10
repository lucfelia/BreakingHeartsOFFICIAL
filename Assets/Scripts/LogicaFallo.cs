using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LogicaFallo : MonoBehaviour
{
    public int dañar = 1;
    public VidaJugador vidaJugador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tecla" )
        {
            GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score--;
            if (vidaJugador != null) { vidaJugador.TomarDaño(dañar); }
        }
    }
}
