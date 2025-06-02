using System.Collections;
using TMPro;
using UnityEngine;

public class LogicaContenedorNC : MonoBehaviour
{
    public GameObject hitTextPrefab;
    public MenuManager menu;

    public float height = 0f;
    public float margin = 0.3f;

    public int missStreak = 0;

    private LogicaJugador jugadorIz;
    private LogicaJugador jugadorDe;

    void Start()
    {
        GameObject iz = GameObject.Find("BeatIz");
        GameObject de = GameObject.Find("BeatDe");

        if (iz != null) jugadorIz = iz.GetComponent<LogicaJugador>();
        if (de != null) jugadorDe = de.GetComponent<LogicaJugador>();
    }

    void Update()
    {
        if (transform.childCount == 0) return;

        // Solo detectar una por frame
        bool teclaProcesada = false;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (teclaProcesada) break;

            Transform teclaActiva = transform.GetChild(i);
            LogicaTeclasNC logica = teclaActiva.GetComponent<LogicaTeclasNC>();
            if (logica == null) continue;

            if (Input.GetKeyDown(logica.keyToCheck))
            {
                LogicaJugador playerLogic = ObtenerJugadorDesdeTecla(logica.keyToCheck);
                if (playerLogic == null) continue;

                GameObject texto = Instantiate(hitTextPrefab, teclaActiva);
                texto.GetComponent<RectTransform>().localPosition = Vector3.zero;

                TextMeshProUGUI textUGUI = texto.GetComponent<TextMeshProUGUI>();
                TextMeshPro textTMP = texto.GetComponent<TextMeshPro>();

                string resultado = "";
                int puntos = 0;

                if (logica.inside)
                {
                    int counter = logica.GetCounter();
                    float y = teclaActiva.position.y;
                    float h = logica.height;
                    bool desdeAbajo = logica.keyToCheck == KeyCode.Z || logica.keyToCheck == KeyCode.M;

                    if (counter == 2)
                    {
                        if ((desdeAbajo && y < h) || (!desdeAbajo && y > h))
                        {
                            resultado = "Early";
                            puntos = 2;
                        }
                        else
                        {
                            resultado = "Late";
                            puntos = 2;
                        }
                    }
                    else
                    {
                        resultado = "Excellent";
                        puntos = 8;
                    }

                    if (textUGUI != null) textUGUI.text = resultado;
                    else if (textTMP != null) textTMP.text = resultado;

                    playerLogic.score += puntos;
                    ActualizarScore(playerLogic);
                    missStreak = 0;
                    teclaActiva.GetComponent<SpriteRenderer>().enabled = false;
                    StartCoroutine(DestroyTecla(teclaActiva));
                    teclaProcesada = true;
                }
                else
                {
                    // tanto si está en missArea como fuera del área
                    if (textUGUI != null) textUGUI.text = "Miss";
                    else if (textTMP != null) textTMP.text = "Miss";

                    missStreak++;
                    if (missStreak >= 3)
                    {
                        missStreak = 0;
                        menu.AbrirMenuAviso();
                    }

                    teclaActiva.GetComponent<SpriteRenderer>().enabled = false;
                    StartCoroutine(DestroyTecla(teclaActiva));
                    teclaProcesada = true;
                }

            }
        }
    }


    LogicaJugador ObtenerJugadorDesdeTecla(KeyCode tecla)
    {
        switch (tecla)
        {
            case KeyCode.Q:
            case KeyCode.Z:
                return jugadorIz;
            case KeyCode.M:
            case KeyCode.P:
                return jugadorDe;
            default:
                return null;
        }
    }

    void ActualizarScore(LogicaJugador jugador)
    {
        jugador.text.text = "Score: " + jugador.score.ToString();
    }

    IEnumerator DestroyTecla(Transform tecla)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(tecla.gameObject);
    }
}




