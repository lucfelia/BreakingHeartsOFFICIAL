using UnityEngine;

public class LogicaFallo : MonoBehaviour
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

        if (collision.gameObject.tag == "Tecla" )
        {
            GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score -= 2;           
        }
    }

}
