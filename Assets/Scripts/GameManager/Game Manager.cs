using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<int> lvlsCompletados = new List<int>();
    public int lvlsUnblocked = 2;

    public Vector2 guardarPosJugador = new Vector2(-12f, -1.5f);
    public int guardarTargetIndex = 0;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(gameObject); }
    }

    public void CompleteLevel(int levelIndex)
    {
        //Confirmar que lvl no se haya repetido
        if (!lvlsCompletados.Contains(levelIndex)) {
            lvlsCompletados.Add(levelIndex);

            //Desbloquear lvl
            if (levelIndex + 1 <= 4) {
                if (levelIndex + 1 > lvlsUnblocked) {
                    lvlsUnblocked = levelIndex + 1;
                }
            }
        }
    }
    public void SavePlayerData(Vector2 position, int targetIndex)
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "SelectorDeNiveles")
        {
            guardarPosJugador = position;
            guardarTargetIndex = targetIndex;
        }
    }

    public Vector2 GetSavedPosition()
    {
        string scene = SceneManager.GetActiveScene().name;
        if (scene == "SelectorDeNiveles")
            return guardarPosJugador;
        return Vector2.zero;
    }

    public int GetSavedTargetIndex()
    {
        string scene = SceneManager.GetActiveScene().name;
        if (scene == "SelectorDeNiveles")
            return guardarTargetIndex;
        return 0;
    }
}
