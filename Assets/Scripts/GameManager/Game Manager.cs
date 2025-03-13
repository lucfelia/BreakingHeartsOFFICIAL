using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int lvlsUnblocked;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(gameObject); }
    }

    // Start is called before the first frame update
    void Start()
    {
        lvlsUnblocked = 0;
    }

    public void CompleteLevel(int levelIndex)
    {
        if (levelIndex + 1 > lvlsUnblocked) {
            lvlsUnblocked = levelIndex + 1;
        }
    }
}
