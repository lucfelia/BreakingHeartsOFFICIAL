using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LogicaJugador : MonoBehaviour
{

    public int score = 0;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        //encuentre a scoreui en unity y saque lo que tiene escrito
        text = GameObject.Find("ScoreUI").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
