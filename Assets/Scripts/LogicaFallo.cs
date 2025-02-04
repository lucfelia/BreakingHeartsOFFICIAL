using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaFallo : MonoBehaviour
{
    public int da�ar = 1;
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
            GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().text.text = "Score: " +
            GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score.ToString();
            if (vidaJugador != null) { vidaJugador.TomarDa�o(da�ar); }

            //SceneManager.LoadScene("SampleScene");

        }
    }
}
