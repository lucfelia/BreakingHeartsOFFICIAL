using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DrumSticks : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float hitDistance = 2f;
    public bool isLeftStick;

    private Vector3 originalPosition;
    private bool hitDown = false;
    private bool hitUp = false;

    public LogicaJugador playerLogic;
    public GameObject hitTextPrefab, textHolder;
    public GameObject Beat_Area;

    void Start()
    {
        originalPosition = transform.position;
        textHolder = GameObject.Find("EstadoTextHolder");
        if (textHolder != null) { Debug.Log("TextHolderDetected"); }
        Beat_Area = GameObject.Find("Beat_Area");
        if (Beat_Area != null) { playerLogic = Beat_Area.GetComponent<LogicaJugador>(); }
    }

    void Update()
    {
        // Detectar teclas
        hitDown = Input.GetKey(KeyCode.DownArrow);
        hitUp = Input.GetKey(KeyCode.UpArrow);
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = originalPosition;

        if (hitDown)
        {
            // Flecha abajo: izquierdo baja, derecho sube
            if (isLeftStick)
                targetPosition = originalPosition + Vector3.down * hitDistance;
            else
                targetPosition = originalPosition + Vector3.up * hitDistance;
        }
        else if (hitUp)
        {
            // Flecha arriba: derecho baja, izquierdo sube
            if (!isLeftStick)
                targetPosition = originalPosition + Vector3.down * hitDistance;
            else
                targetPosition = originalPosition + Vector3.up * hitDistance;
        }

        // Mover suavemente
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tambor"))
        {
            GameObject HitTextInstance = Instantiate(hitTextPrefab, textHolder.transform);
            HitTextInstance.transform.GetComponent<TextMeshProUGUI>().SetText("Perfect");
            playerLogic.score += 4;
            playerLogic.text.text = "Score: " + playerLogic.score.ToString();
        }
    }

}



