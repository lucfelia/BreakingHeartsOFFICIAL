using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaFalloNightCoreIz : MonoBehaviour
{

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

        if (collision.gameObject.tag == "Tecla")
        {
            GameObject.Find("BeatIz").GetComponent<LogicaJugador>().score -= 4;
        }
    }
}
