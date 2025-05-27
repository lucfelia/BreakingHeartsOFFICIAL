using System.Collections;
using TMPro;
using UnityEngine;

public class LogicaContenedor : MonoBehaviour
{
    public GameObject hitTextPrefab;
    public LogicaJugador playerLogic;
    public MenuManager menu;

    public float height = 0f;
    public float margin = 0.3f;

    public int missStreak = 0;

    private bool limitReached = false;

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0) return;

        Transform teclaActiva = transform.GetChild(0);
        LogicaTeclas logica = teclaActiva.GetComponent<LogicaTeclas>();

        if (logica == null) return;

        float y = teclaActiva.position.y;

        if (Input.GetKeyDown(logica.keyToCheck))
        {
            if (logica.inside && y >= height - margin && y <= height + margin)
            {
                MostrarTexto("AMAZING!!!", teclaActiva);
                playerLogic.score += 4;
                ActualizarScore();
                missStreak = 0;
                teclaActiva.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(DestroyTecla(teclaActiva));
            }
            else if (logica.inside && y > height)
            {
                MostrarTexto("Early..", teclaActiva);
                playerLogic.score += 2;
                ActualizarScore();
                missStreak = 0;
                teclaActiva.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(DestroyTecla(teclaActiva));
            }
            else if (logica.inside && y < height)
            {
                MostrarTexto("Late..", teclaActiva);
                playerLogic.score += 2;
                ActualizarScore();
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

        //Si llega demasiado abajo también se cuenta como miss
        if (y <= -3f && !limitReached)
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

    void ActualizarScore()
    {
        playerLogic.text.text = "Score: " + playerLogic.score.ToString();
    }

    IEnumerator DestroyTecla(Transform tecla) {
        yield return new WaitForSeconds(0.5f);
        Destroy(tecla.gameObject);
        limitReached = false;
    }
}