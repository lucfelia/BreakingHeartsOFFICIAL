using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject PauseMenu;
    private bool PausedGame = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (PausedGame)
            {
                Reanudar();
            }
            else 
            {
                Pausa();
            }
        }
    }
    public void Pausa()
    {
        PausedGame = true;
        Time.timeScale = 0f;
        PauseButton.SetActive(false);
        PauseMenu.SetActive(true);
    }
    
    public void Reanudar()
    {
        PausedGame = false;
        Time.timeScale = 1f;
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
    }
    
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnLevelSelector()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SelectorDeNiveles");
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
    }
}
