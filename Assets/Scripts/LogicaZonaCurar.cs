using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaZonaCurar : MonoBehaviour
{
    bool inside = false;
    public VidaJugador vidaJugador;
    public int curar = 1;
    public bool curado = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inside == true)
            {
                Debug.Log("Curado");
                if (vidaJugador != null)
                {
                    vidaJugador.CurarVida(curar);                    
                }
            }

            else if (inside == false)
            {
                Debug.Log("Asi no te curas bobo");
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inside = true;
        Debug.Log("Colision :p");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inside = false;
    }
}
