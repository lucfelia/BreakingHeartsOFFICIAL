using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class LogicaTeclas : MonoBehaviour
{
    public KeyCode keyToCheck;

    public float speed;
    public int counter = 0;
    public int missCounter = 0;
    public float height = 0f;
    public float margin = 0.3f;
    public bool inside = false;
    public bool missInside = false;
    float vertical;

    public GameObject Beat_Area;

    public LogicaJugador playerLogic;
    public GameObject hitTextPrefab, textHolder;
    public GameObject menuManager;
    private MenuManager menu;

    int missStreak = 0;

    bool checkKey = false;

    // Start is called before the first frame update
    void Start()
    {
        vertical = -1f;
        textHolder = GameObject.Find("EstadoTextHolder");
        if (textHolder != null) { Debug.Log("TextHolderDetected"); }
        menuManager = GameObject.Find("Canvas");
        menu = menuManager.GetComponent<MenuManager>();
        Beat_Area = GameObject.Find("Beat_Area");
        if (Beat_Area != null) { playerLogic = Beat_Area.GetComponent<LogicaJugador>(); }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, vertical).normalized;

        transform.position += direction * speed * Time.deltaTime;

        //verificar si la tecla esta dentro
        inside = (counter == 2 || counter == 3);
        missInside = (missCounter == 1);

        if (transform.position.y <= -3f)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(keyToCheck))
        {
            if (inside && transform.position.y >= height - margin && transform.position.y <= height + margin)
            {
                //Perfect
                GameObject HitTextInstance = Instantiate(hitTextPrefab, textHolder.transform);
                HitTextInstance.transform.GetComponent<TextMeshProUGUI>().SetText("Excellent");
                playerLogic.score += 4;
                playerLogic.text.text = "Score: " + playerLogic.score.ToString();
                missStreak = 0;
            }
            else if (inside && transform.position.y > height)
            {
                //Early
                GameObject HitTextInstance = Instantiate(hitTextPrefab, textHolder.transform);
                HitTextInstance.transform.GetComponent<TextMeshProUGUI>().SetText("Early");
                playerLogic.score += 2;
                playerLogic.text.text = "Score: " + playerLogic.score.ToString();
                missStreak = 0;
            }
            else if (inside && transform.position.y < height)
            {
                //Late
                GameObject HitTextInstance = Instantiate(hitTextPrefab, textHolder.transform);
                HitTextInstance.transform.GetComponent<TextMeshProUGUI>().SetText("Late");
                playerLogic.score += 2;
                playerLogic.text.text = "Score: " + playerLogic.score.ToString();
                missStreak = 0;
            }

            if (inside)
            {
                Destroy(gameObject);
                Debug.Log("Arrow Destroyed: " + gameObject.name);
            }
            else if (missInside)
            {
                //Miss
                GameObject HitTextInstance = Instantiate(hitTextPrefab, textHolder.transform);
                HitTextInstance.transform.GetComponent<TextMeshProUGUI>().SetText("Miss");
                missStreak++;
                if (missStreak >= 3)
                {
                    menu.panel.SetActive(false);
                    menu.escogiendoBeat = false;
                    menu.playingClassic = false;
                    menu.gameplayUI.SetActive(false);
                    menu.AbrirMenuContraataque();
                }
                missInside = false;
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { counter++; }
        if (collision.gameObject.tag == "MissArea") { missCounter++; }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { counter--; }
        if (collision.gameObject.tag == "MissArea") { missCounter--; }
    }


}
