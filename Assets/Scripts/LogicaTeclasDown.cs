using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LogicaTeclasDown : MonoBehaviour
{
    public float speed;
    public int counter = 0;
    public bool inside = false;
    float vertical;
    public float minY = 0.5f;
    public float maxY = -1.25f;

   
    // Start is called before the first frame update
    void Start()
    {
        vertical = -1f;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, vertical).normalized;

        transform.position += direction * speed * Time.deltaTime;

        //verificar si la tecla esta dentro
        if (counter == 3)
        {
            inside = true;
        }
        else if (counter == 2)
        {
            inside = true;
        }
        else
        {
            inside = false;
        }

        if (transform.position.y <= -5.28f)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(inside == true)
            {
                GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score++;
                GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().text.text = "Score: " +
                    GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score.ToString();

                if (counter == 2 /*&& transform.position.y >= transform.position.minY*/)
                {
                    Debug.Log("Early!!");
                }
                else if (counter == 2 /*&& transform.position.y <= maxY*/)
                {
                    Debug.Log("Late!!");
                }
                else
                {
                    Debug.Log("Excelent!!");
                }
                Destroy(gameObject);
            }
        }

    }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
            counter++;
            }
        } 
    
        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
            counter--;
            }
        }
}
