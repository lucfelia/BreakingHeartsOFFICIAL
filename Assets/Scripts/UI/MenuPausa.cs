using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuPausa : MonoBehaviour
{
    private EventSystem eventSystem;
    public GameObject inicioDefault;

    private AudioSource au;

    public GameObject PauseButton;
    public GameObject PauseMenu;
    //public GameObject workInProgress;
    //public GameObject ControlsworkInProgress;
    private bool PausedGame = false;

    private void Start()
    {
        eventSystem = EventSystem.current;
        au = GetComponent<AudioSource>();
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
    }

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
        //if (Input.GetKeyDown(KeyCode.F1))
        //{
        //    ShowControls();
        //}
        //else if (Input.GetKeyUp(KeyCode.F1))
        //{
        //    HideControls();
        //}
    }

    public void Pausa()
    {
        au.Play();
        eventSystem.SetSelectedGameObject(inicioDefault);
        PausedGame = true;
        Time.timeScale = 0f;
        PauseButton.SetActive(false);
        PauseMenu.SetActive(true);
    }
    
    public void Reanudar()
    {
        au.Play();
        PausedGame = false;
        Time.timeScale = 1f;
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
    }
    private IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(0.5f); // Wait for sound to finish
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Reiniciar()
    {
        au.Play();
        StartCoroutine(ResetGame()); 
        Time.timeScale = 1f;
    }

    private IEnumerator ReturnLVL(string sceneName) {
        yield return new WaitForSeconds(0.5f); // Wait for sound to finish
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
    public void ReturnLevelSelector()
    {
        au.Play(); 
        StartCoroutine(ReturnLVL("SelectorDeNiveles"));
    }

    public void TitleScreen()
    {
        au.Play();
        StartCoroutine(ReturnLVL("TitleScreen"));
    }
    private IEnumerator Quit()
    {
        yield return new WaitForSeconds(0.5f); // Wait for sound to finish
        Debug.Log("Cerrando juego");
        Application.Quit();
    }
    public void Cerrar()
    {
        au.Play();
        StartCoroutine(Quit());
    }
    //public void OpenSettigns()
    //{
    //    au.Play();
    //    workInProgress.SetActive(true);
    //}
    //public void CloseSettings()
    //{
    //    au.Play();
    //    workInProgress.SetActive(false);
    //}
    //public void ShowControls() 
    //{
    //    au.Play();
    //    ControlsworkInProgress.SetActive(true);
    //}
    //public void HideControls() 
    //{
    //    au.Play();
    //    ControlsworkInProgress.SetActive(false);
    //}
}
