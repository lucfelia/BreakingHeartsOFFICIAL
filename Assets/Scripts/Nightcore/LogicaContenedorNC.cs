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

    private bool limitReached = false;

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
        Transform teclaActiva = transform.GetChild(0);
        LogicaTeclasNC logica = teclaActiva.GetComponent<LogicaTeclasNC>();
        if (logica == null) return;

        float y = teclaActiva.position.y;
        float x = teclaActiva.position.x;

        // Si se presiona la tecla, se procesa el resultado
        if (Input.GetKeyDown(logica.keyToCheck))
        {
            if (logica.inside && y >= height - margin && y <= height + margin)
            {
                MostrarTexto("AMAZING!!!", teclaActiva);
                ActualizarScore(4);
                missStreak = 0;
                teclaActiva.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(DestroyTecla(teclaActiva));
            }
            else if (logica.inside && y > height)
            {
                MostrarTexto("Early..", teclaActiva);
                ActualizarScore(2);
                missStreak = 0;
                teclaActiva.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(DestroyTecla(teclaActiva));
            }
            else if (logica.inside && y < height)
            {
                MostrarTexto("Late..", teclaActiva);
                ActualizarScore(2);
                missStreak = 0;
                teclaActiva.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(DestroyTecla(teclaActiva));
            }
            else if (logica.missInside)
            {
                MostrarTexto("Miss", teclaActiva);
                missStreak++;
                if (missStreak >= 3)
                {
                    missStreak = 0;
                    limitReached = false;
                    menu.AbrirMenuAviso();
                }
                teclaActiva.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(DestroyTecla(teclaActiva));
            }
        }

        // Si la tecla se pasa del límite
        if (x <= 2.5f && x >= -2.5f && !limitReached)
        {
            limitReached = true;
            MostrarTexto("Miss", teclaActiva);
            missStreak++;
            if (missStreak >= 3)
            {
                missStreak = 0;
                limitReached = false;
                menu.AbrirMenuAviso();
            }
            teclaActiva.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(DestroyTecla(teclaActiva));
        }
    }

    void MostrarTexto(string mensaje, Transform tecla)
    {
        if (transform.childCount == 0) return;  // No hay hijos, nada que mostrar

        GameObject texto = Instantiate(hitTextPrefab, tecla);
        texto.GetComponent<RectTransform>().localPosition = Vector3.zero;
        texto.GetComponent<TextMeshPro>().SetText(mensaje);
    }

    void ActualizarScore(int puntos)
    {
        jugadorIz.score += puntos;
        jugadorDe.score += puntos;
        jugadorIz.text.text = "Score: " + jugadorIz.score.ToString();
        jugadorDe.text.text = "Score: " + jugadorDe.score.ToString();
    }

    IEnumerator DestroyTecla(Transform tecla)
    {
        yield return new WaitForSeconds(0.25f); // Temporizador ajustado
        Destroy(tecla.gameObject);
        limitReached = false;
    }
}