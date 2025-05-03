using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public void PauseForSeconds(float seconds)
    {
        StartCoroutine(PauseGameForDuration(seconds));
    }

    IEnumerator PauseGameForDuration(float duration)
    {
        // Pausar el juego
        Time.timeScale = 0;

        // Esperar la duración especificada
        yield return new WaitForSecondsRealtime(duration);

        // Reanudar el juego
        Time.timeScale = 1;
    }
}