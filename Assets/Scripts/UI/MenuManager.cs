using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    //Event system
    public EventSystem eventSystem;
    public VidaJugador vidaJugador;

    //Menus
    //Inicial
    public GameObject menuInicial;
    public GameObject inicioDefault;
    public GameObject gameplayUI;
        //Beats
    public bool escogiendoBeat = false;
    public GameObject[] menuBeats;
    public GameObject beatDefault;
    private bool puedocurar = false;
    public Button curarDefault;
        //panel
    public GameObject panel;

    //Gameplays
        //Classic beat
    public bool playingClassic = false;
    public GameObject[] classicBeatGameplay;
        //Nightcore beat
    public bool playingNightcore = false;
    public GameObject[] nightcoreBeatGameplay;
        //Reggaeton beat
    public bool playingReggaeton = false;
    public GameObject[] reggaetonBeatGameplay;
        //Contraataque beat
    public bool playingContraataque = false;
    public GameObject[] contraataqueGameplay;

    //Curar
    public GameObject curarGameplay;
    
    //Gameover
    public GameObject gameover;
    public GameObject gameoverDefault;

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
        playingNightcore = false;
        playingReggaeton = false;
        playingContraataque = false;
        puedocurar = false;
        curarGameplay.SetActive(false);
        gameover.SetActive(false);
        gameplayUI.SetActive(false);
    }
    private void Update()
    {
        if (vidaJugador.vidaActual == vidaJugador.vidaMax) { puedocurar = false; }
        else { puedocurar = true; }
        curarDefault.interactable = puedocurar;

        if (playingClassic) { foreach (GameObject game in classicBeatGameplay) game.SetActive(true); } 
        else { foreach (GameObject game in classicBeatGameplay) game.SetActive(false); }

        if (playingNightcore) { foreach (GameObject game in nightcoreBeatGameplay) game.SetActive(true); } 
        else { foreach (GameObject game in nightcoreBeatGameplay) game.SetActive(false); }

        if (playingReggaeton) { foreach (GameObject game in reggaetonBeatGameplay) game.SetActive(true); }
        else { foreach (GameObject game in reggaetonBeatGameplay) game.SetActive(false); }

        if (escogiendoBeat) { foreach (GameObject beat in menuBeats) beat.SetActive(true); } 
        else { foreach (GameObject beat in menuBeats) beat.SetActive(false); }

        if (playingContraataque) { foreach (GameObject contraataque in contraataqueGameplay) contraataque.SetActive(true); } 
        else { foreach (GameObject contraataque in contraataqueGameplay) contraataque.SetActive(false); }
    }

    public void AbrirMenuInicial()
    {
        Debug.Log("[MenuManager.cs] - Inicio");
        //desactivado:
        escogiendoBeat = false;
        playingContraataque = false;
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
        gameplayUI.SetActive(true);
    }
    public void AbrirMenuNightcoreGameplay()
    {
        Debug.Log("[MenuManager.cs] - Nightcore Gameplay");
        //desactivado:
        panel.SetActive(false);
        escogiendoBeat = false;
        //activado:
        playingNightcore = true;
        gameplayUI.SetActive(true);
    }
    public void AbrirMenuReggaetonGameplay()
    {
        Debug.Log("[MenuManager.cs] - Reggaeton Gameplay");
        //desactivado:
        panel.SetActive(false);
        escogiendoBeat = false;
        //activado:
        playingReggaeton = true;
        gameplayUI.SetActive(true);
    }
    public void AbrirMenuContraataque()
    {
        Debug.Log("[MenuManager.cs] - Contraataque");
        //desactivado:
        playingClassic = false;
        playingReggaeton = false;
        playingNightcore = false;
        gameplayUI.SetActive(false);
        curarGameplay.SetActive(false);
        //activado:
        playingContraataque = true;
    }
    public void AbrirMenuCurar()
    {
        Debug.Log("[MenuManager.cs] - Curar Gameplay");
        //desactivado:
        panel.SetActive(false);
        menuInicial.SetActive(false);
        playingContraataque = false;
        //activado:
        curarGameplay.SetActive(true);
    }
    public void AbrirMenuGameover()
    {
        Debug.Log("[MenuManager.cs] - Gameover");
        //desactivado:
        Time.timeScale = 0;
        //activado:
        gameover.SetActive(true);
        eventSystem.SetSelectedGameObject(gameoverDefault);
    }
    public void ReiniciarNivel()
    {
        Debug.Log("[MenuManager.cs] - Reinicio");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}