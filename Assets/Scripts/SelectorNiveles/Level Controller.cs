using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance { get; private set; }
    public CameraController cameraController;

    public int targetIndex;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(gameObject); }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SelectorDeNiveles")
        {
            GameObject player = GameObject.Find("Player");
            cameraController = player.GetComponent<CameraController>();
            // Get the targetIndex from the CameraController
            targetIndex = cameraController.targetIndex;

            if (cameraController.onNode && Input.GetKeyDown(KeyCode.Return))
            {
                if (targetIndex <= GameManager.Instance.lvlsUnblocked)
                {
                    SceneManager.LoadScene($"Batalla_{targetIndex + 1}");
                }
            }
        }
    }
}