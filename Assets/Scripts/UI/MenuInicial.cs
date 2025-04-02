using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuInicial : MonoBehaviour
{
    private EventSystem eventSystem;
    public GameObject inicioDefault;
    private AudioSource au;

    private void Start()
    {
        eventSystem = EventSystem.current;
        au = GetComponent<AudioSource>();
        eventSystem.SetSelectedGameObject(inicioDefault);
    }

    private IEnumerator ChangeSceneAfterSound(string sceneName)
    {
        yield return new WaitForSeconds(0.5f); // Wait for sound to finish
        SceneManager.LoadScene(sceneName);
    }

    public void StartGame()
    {
        au.Play();
        StartCoroutine(ChangeSceneAfterSound("SelectorDeNiveles"));
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
    }

    public void OpenSettigns()
    {

    }
    public void CloseSettings()
    {

    }
}
