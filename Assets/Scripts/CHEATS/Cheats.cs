using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("Batalla_1");
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            StartCoroutine(CargarNivelConCheats(2));
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            StartCoroutine(CargarNivelConCheats(3));
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator CargarNivelConCheats(int nivel)
    {
        if (nivel == 2)
        {
            AgregarNivelCompletado(0);
            AgregarNivelCompletado(1);
            GameManager.Instance.lvlsUnblocked = 2;
            yield return null;
            SceneManager.LoadScene("Batalla_2");
        }
        else if (nivel == 3)
        {
            AgregarNivelCompletado(0);
            AgregarNivelCompletado(1);
            AgregarNivelCompletado(2);
            GameManager.Instance.lvlsUnblocked = 3;
            yield return null;
            SceneManager.LoadScene("Batalla_3");
        }
    }

    void AgregarNivelCompletado(int lvl)
    {
        if (!GameManager.Instance.lvlsCompletados.Contains(lvl))
        {
            GameManager.Instance.lvlsCompletados.Add(lvl);
        }
    }
}

