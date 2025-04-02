using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuInicial : MonoBehaviour
{
    private EventSystem eventSystem;
    public GameObject inicioDefault;
    public GameObject splashUI;
    public GameObject creditsUI;
    public GameObject settingsUI;
    private AudioSource au;

    private void Start()
    {
        eventSystem = EventSystem.current;
        au = GetComponent<AudioSource>();
        eventSystem.SetSelectedGameObject(inicioDefault);
        splashUI.SetActive(true);
        settingsUI.SetActive(false);
        creditsUI.SetActive(false);
    }

    private IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }

    public void StartGame()
    {
        au.Play();
        StartCoroutine(ChangeScene("SelectorDeNiveles"));
    }
    private IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Cerrando juego");
        Application.Quit();
    }
    public void Cerrar()
    {
        au.Play();
        StartCoroutine(QuitGame());
    }

    public void OpenSettigns()
    {
        au.Play();
        settingsUI.SetActive(true);
    }

    public void OpenCredits()
    {
        au.Play();
        creditsUI.SetActive(true);

    }

    public void ReturnMainMenu()
    {
        au.Play();
        settingsUI.SetActive(false);
        creditsUI.SetActive(false);
        eventSystem.SetSelectedGameObject(inicioDefault);
    }
}
