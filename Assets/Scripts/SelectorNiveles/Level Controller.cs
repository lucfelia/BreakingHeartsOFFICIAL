using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance { get; private set; }
    public PlayerController playerController;

    public int targetIndex;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SelectorDeNiveles")
        {
            GameObject player = GameObject.Find("Player");
            playerController = player.GetComponent<PlayerController>();
            // Get the targetIndex from the PlayerController
            targetIndex = playerController.targetIndex;

            if (playerController.onNode && Input.GetKeyDown(KeyCode.Return))
            {
                if (targetIndex <= GameManager.Instance.lvlsUnblocked)
                {
                    SceneManager.LoadScene($"Batalla_{targetIndex}");
                }
            }
        }
    }
}