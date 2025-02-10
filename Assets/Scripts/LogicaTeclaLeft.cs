using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class LogicaTeclaLeft : MonoBehaviour
{
   public int dañar = 1;
   public GameObject Enemigo;
   public VidaEnemigo logicavidaEnemigo;
   public float speed;
   public int counter = 0;
   public bool inside = false;
   float vertical;
   public float minY = 0f;
   public float maxY = -1.25f;

   TextMeshProUGUI hitText;


    // Start is called before the first frame update
    void Start()
    {
        vertical = -1f;
        Enemigo = GameObject.Find("Enemigo");
        if (Enemigo != null) { logicavidaEnemigo = Enemigo.GetComponent<VidaEnemigo>(); }
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
                GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score++;
                GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().text.text = "Score: " +
                GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score.ToString();

                if (transform.position.y > minY)
                {
                   ShowText("Early!!");
                }
                else if (transform.position.y <= maxY)
                {
                    ShowText("Late!!");
                }
                else
                {
                    ShowText("Excelent!!");
                }

                if (GameObject.Find("Beat_Area").GetComponent<LogicaJugador>().score % 20 == 0 )
                {
                    Debug.Log("Enemigo ouch");
                    logicavidaEnemigo.TomarDaño(dañar);
                    //if (vidaEnemigo != null) { vidaEnemigo.TomarDaño(dañar); }
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
            StartCoroutine(ClearTextAfterDelay(1f));
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
