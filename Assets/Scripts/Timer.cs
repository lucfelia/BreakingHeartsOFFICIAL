using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Timer : MonoBehaviour
{
    private float timer = 0f;

    public float timeStop = 10f;
    public float timeMenu = 12.5f;

    public GameObject menuInicial;
    public GameObject generador;
    public GameObject menuGameplay;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);


        if (timer >= timeStop)
        {
            Debug.Log(timer);
            Debug.Log(timeStop);
            Debug.Log("acaba teclas");
            generador.SetActive(false);
        }
        if (timer >= timeMenu)
        {
            Debug.Log(timer);
            Debug.Log(timeStop);
            Debug.Log("volver a menu ataque");
            menuInicial.SetActive(true);
            generador.SetActive(true);
            menuGameplay.SetActive(false);
            timer = 0f;
        }
        timer += Time.deltaTime;
    }
}
