using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    void Start()
    {

            // Desbloquea todos los niveles y ataques al iniciar
            GameManager.Instance.lvlsUnblocked = 3; // Número máximo de niveles
            GameManager.Instance.lvlsCompletados = new List<int> { 0, 1, 2 }; // Niveles 1, 2, 3
        
    }
    void Update()
    {
        // Cheats para cambiar de nivel (ignora lvlsUnblocked)
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("Batalla_1");
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene("Batalla_2");
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene("Batalla_3");
        }
        // Cheat para reiniciar nivel
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
