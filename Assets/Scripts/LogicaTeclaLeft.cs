using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class LogicaTeclaLeft : MonoBehaviour
{
    public float speed;
    public int counter = 0;
    public bool inside = false;
    float vertical;
    public float height = 0f;
    public GameObject Textos;
    public LogicaTextos LogicaTextos;

    // Start is called before the first frame update
    void Start()
    {
        vertical = -1f;
        Textos = GameObject.Find("Textos");
        if (Textos != null) { LogicaTextos = Textos.GetComponent<LogicaTextos>(); }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, vertical).normalized;

        transform.position += direction * speed * Time.deltaTime;

        //verificar si la tecla esta dentro
        inside = (counter == 2 || counter == 3);

        if (transform.position.y <= -5.28f)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (inside)
            {
                if (counter == 2)
                {
                    if (transform.position.y > height)
                    {
                        LogicaTextos.UpdateScore(2);
                        LogicaTextos.ShowText("Early!!");
                    }
                    else if (transform.position.y < height)
                    {
                        LogicaTextos.UpdateScore(2);
                        LogicaTextos.ShowText("Late!!");
                    }
                }
                else
                {
                    LogicaTextos.UpdateScore(4);
                    LogicaTextos.ShowText("Excellent!!");
                }
                Destroy(gameObject);
                Debug.Log("Arrow Destroyed: " + gameObject.name);
            }
            
        }
        LogicaTextos.UpdateTextShowTime();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { counter++; }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { counter--; }
    }
}