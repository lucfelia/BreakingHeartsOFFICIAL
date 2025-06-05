using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimManager : MonoBehaviour
{
    public GameObject[] panels;

    public static AnimManager AnimInstance { get; private set; }
    void Awake()
    {
        if (AnimInstance == null)
        {
            AnimInstance = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(gameObject); }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene escena, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "SelectorDeNiveles") {
            foreach (GameObject pans in panels) {
                pans.SetActive(true);
            }
        }
    }
}