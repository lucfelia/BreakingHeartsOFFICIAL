using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //Event system
    public EventSystem eventSystem;
    public VidaJugador vidaJugador;

    //Menus
    //Inicial
    public GameObject menuInicial;
    public GameObject inicioDefault;
        //Beats
    public bool escogiendoBeat = false;
    public GameObject[] menuBeats;
    public GameObject beatDefault;
    public bool puedocurar = false;
    public Button curarDefault;
        //panel
    public GameObject panel;

    //Gameplays
    public bool playingClassic = false;
        //Classic beat
    public GameObject[] classicBeatGameplay;

    //Otras mecanicas
        //Curar
    public GameObject curarGameplay;
        //Contraataque
    public GameObject contraataqueGameplay;
    
    //Gameover
    public GameObject gameover;

    private void Start()
    {
        //activado:
        panel.SetActive(true);
        menuInicial.SetActive(true);
        eventSystem.SetSelectedGameObject(inicioDefault);
        //desactivado:
        curarDefault.interactable = puedocurar;
        escogiendoBeat = false;
        playingClassic = false;
        puedocurar = false;
        curarGameplay.SetActive(false);
        contraataqueGameplay.SetActive(false);
        gameover.SetActive(false);
    }

    private void Update()
    {
        
        if (vidaJugador.vidaActual == vidaJugador.vidaMax) { puedocurar = false; }
        else { puedocurar = true; }
        curarDefault.interactable = puedocurar;

        if (playingClassic) {
            foreach (GameObject game in classicBeatGameplay) game.SetActive(true);
        } else {
            foreach (GameObject game in classicBeatGameplay) game.SetActive(false);
        }

        if (escogiendoBeat) {
            foreach (GameObject beat in menuBeats) beat.SetActive(true);
        } else {
            foreach (GameObject beat in menuBeats) beat.SetActive(false);
        }
    }

    public void AbrirMenuInicial()
    {
        Debug.Log("[MenuManager.cs] - Inicio");
        //desactivado:
        escogiendoBeat = false;
        contraataqueGameplay.SetActive(false);
        curarGameplay.SetActive(false);
        //activado:
        panel.SetActive(true);
        menuInicial.SetActive(true);
        eventSystem.SetSelectedGameObject(inicioDefault);
    }
    public void AbrirMenuBeats()
    {
        Debug.Log("[MenuManager.cs] - Elegir Beat");
        //desactivado:
        menuInicial.SetActive(false);
        //activado:
        escogiendoBeat = true;
        panel.SetActive(true);
        eventSystem.SetSelectedGameObject(beatDefault);
    }
    public void AbrirMenuClassicGameplay()
    {
        Debug.Log("[MenuManager.cs] - Classic Gameplay");
        //desactivado:
        panel.SetActive(false);
        escogiendoBeat = false;
        //activado:
        playingClassic = true;
    }
    public void AbrirMenuContraataque()
    {
        Debug.Log("[MenuManager.cs] - Contraataque");
        //desactivado:
        playingClassic = false;
        curarGameplay.SetActive(false);
        //activado:
        contraataqueGameplay.SetActive(true);
    }

    public void AbrirMenuCurar()
    {
        Debug.Log("[MenuManager.cs] - Curar Gameplay");
        //desactivado:
        panel.SetActive(false);
        menuInicial.SetActive(false);
        contraataqueGameplay.SetActive(false);
        //activado:
        curarGameplay.SetActive(true);
    }

    public void AbrirMenuGameover()
    {
        Debug.Log("[MenuManager.cs] - Gameover");
        //desactivado:
        Time.timeScale = 0;
        playingClassic = false;
        //activado:
        gameover.SetActive(true);
    }

    public void ReiniciarNivel()
    {
        Debug.Log("[MenuManager.cs] - Reinicio");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
