using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogicaPalos : MonoBehaviour
{

    float smooth = 50.0f;
    float tiltAngle = 75f;
    public float beatTime = 0.10f;
    public float time = 0f;
    public LogicaJugador playerLogic;
    public GameObject hitTextPrefab, textHolder;
    public GameObject Beat_Area;

    private void Start()
    {
        textHolder = GameObject.Find("EstadoTextHolder");
        if (textHolder != null) { Debug.Log("TextHolderDetected"); }

        Beat_Area = GameObject.Find("BeatReg");
        if (Beat_Area != null) { playerLogic = Beat_Area.GetComponent<LogicaJugador>(); }
    }

    // Update is called once per frame
    void Update()
    {
        time += 0.1f;

        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, 30 * smooth);

        if (time == beatTime)
        {
            time = 0f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit Tambor");

        if (time <= beatTime - 3) 
        {
            GameObject HitTextInstance = Instantiate(hitTextPrefab, textHolder.transform);
            HitTextInstance.transform.GetComponent<TextMeshProUGUI>().SetText("Early");
            playerLogic.score += 2;
            playerLogic.text.text = "Score: " + playerLogic.score.ToString();
            Debug.Log("EARLY");
        }
        else if (time >= beatTime - 2 || time < beatTime + 2)
        {
            GameObject HitTextInstance = Instantiate(hitTextPrefab, textHolder.transform);
            HitTextInstance.transform.GetComponent<TextMeshProUGUI>().SetText("Excellent");
            playerLogic.score += 4;
            playerLogic.text.text = "Score: " + playerLogic.score.ToString();
            Debug.Log("PERFECT");
        }
        else
        {
            GameObject HitTextInstance = Instantiate(hitTextPrefab, textHolder.transform);
            HitTextInstance.transform.GetComponent<TextMeshProUGUI>().SetText("Late");
            playerLogic.score += 2;
            playerLogic.text.text = "Score: " + playerLogic.score.ToString();
            Debug.Log("LATE");
        }

    }

}
