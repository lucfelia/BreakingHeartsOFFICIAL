using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackLvlSelect : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            SceneManager.LoadScene("SelectorDeNiveles");
        }
    }
}