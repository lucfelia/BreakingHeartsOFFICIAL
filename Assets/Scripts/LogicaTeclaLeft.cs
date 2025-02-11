using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class LogicaTeclaLeft : MonoBehaviour
{
   public float speed;
   public int counter = 0;
   public bool inside = false;
   float vertical;
   public float height = 0f;

   TextMeshProUGUI hitText;


    // Start is called before the first frame update
    void Start()
    {
        vertical = -1f;

        hitText = GameObject.Find("Hit Text").GetComponent<TextMeshProUGUI>();

        if (hitText != null)
        {
            hitText.text = "";
        }

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

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(inside == true)
            {
                if (counter == 2)
                {
                    if (transform.position.y > height)
                    {
                        GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score += 2;
                        GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().text.text = "Score: " +
                        GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score.ToString();
                        ShowText("Early!!");
                    }
                    else if (transform.position.y < height)
                    {
                    GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score += 2;
                    GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().text.text = "Score: " +
                    GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score.ToString();
                        ShowText("Late!!");
                    }
                }
                else
                {
                    GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score += 4;
                    GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().text.text = "Score: " +
                    GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score.ToString();
                    ShowText("Excelent!!");
                }

                Destroy(gameObject);
            }
        }

    }

    private void ShowText(string message)
    {
        if (hitText != null)
        {
            hitText.text = message;
            StartCoroutine(ClearTextAfterDelay(5f));
        }
    }

    private IEnumerator ClearTextAfterDelay(float delay)
    {

        yield return new WaitForSeconds(delay);

        hitText.text = "";

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
