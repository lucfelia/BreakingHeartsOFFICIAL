using UnityEngine;

public class LogicaFalloNightCoreIz : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Tecla")
        {
            GameObject.Find("BeatIz").GetComponent<LogicaJugador>().score -= 4;
        }
    }
}
