using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackLvlSelect : MonoBehaviour
{

    public string nameScene = "SelectorDeNiveles";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            SceneManager.LoadScene(nameScene);
        }
    }
}