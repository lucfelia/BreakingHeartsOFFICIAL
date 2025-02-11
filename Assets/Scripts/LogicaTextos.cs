using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogicaTextos : MonoBehaviour
{
    public GameObject hitText;
    public LogicaJugador playerLogic;

    //teclas
    public GameObject teclaLeft;
    private LogicaTeclaLeft teclaLeftLogica;

    public GameObject teclaUp;
    private LogicaTeclaUp teclaUpLogica;

    public GameObject teclaDown;
    private LogicaTeclasDown teclaDownLogica;

    public GameObject teclaRight;
    private LogicaTeclaRight teclaRightLogica;
    //demasiadas teclas

    private List<GameObject> screenTexts = new List<GameObject>();    
    private float time;

    private Transform parentText;
    


    // Start is called before the first frame update
    void Start() {
        time = 0f;
        parentText = hitText.transform;
    }
    void Update()
    {

    }

    public void UpdateScore(int points) {
        playerLogic.score += points;
        playerLogic.text.text = "Score: " + playerLogic.score.ToString();
    }

    public void ShowText(string message) {
        //if there are no texts, doesn't do anything
        if (hitText == null || parentText == null) return;

        //new hitText is created with the message previously assigned
        GameObject newTextObj = Instantiate(hitText, parentText);
        TextMeshProUGUI newText = newTextObj.GetComponent<TextMeshProUGUI>();
        newText.text = message;
        screenTexts.Add(newTextObj);
        time = 0f;
        
        
    }
    public void UpdateTextShowTime() {
        if (screenTexts.Count == 0) return;
        time += Time.deltaTime;

        if (time >= 1.5f)
        {
            Destroy(screenTexts[0]);
            screenTexts.RemoveAt(0);
            time = 0f; // Reset timer
        }
        
        // Reposition
        for (int i = 0; i < screenTexts.Count; i++) {
            RectTransform rt = screenTexts[i].GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(100, 50);
            rt.localPosition = new Vector3(0, -30f * i, 0);
        }
    }
}
