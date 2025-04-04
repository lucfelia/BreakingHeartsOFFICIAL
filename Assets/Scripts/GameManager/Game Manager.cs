using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<int> lvlsCompletados = new List<int>();
    public int lvlsUnblocked;

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
            if (levelIndex + 1 <= 3) {
                if (levelIndex + 1 > lvlsUnblocked) {
                    lvlsUnblocked = levelIndex + 1;
                }
            }
        }
    }
}
