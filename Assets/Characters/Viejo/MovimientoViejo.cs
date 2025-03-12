using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoViejo : MonoBehaviour
{
    //Variables
    private Vector3 originalPosition;
    private Vector3 targetOffset = new Vector3(+2f, -0.5f, 0f); //left movement
    public float speed = 5f;
    public MenuManager menuManager;
    private bool move = false;

    public float parallaxFactor = 0.1f; // speed

    private Vector3 startMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        startMousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (move) {
            transform.position = Vector3.Lerp(transform.position, originalPosition + targetOffset, speed * Time.deltaTime);

        }
        else {
            transform.position = Vector3.Lerp(transform.position, originalPosition, speed * Time.deltaTime);
        }
        if (menuManager.curarGameplay.activeSelf) { move = true; }
        else { move = false; }
        if (menuManager.menuInicial.activeSelf || menuManager.escogiendoBeat) {
            Vector3 mouseDelta = (Input.mousePosition - startMousePosition) * parallaxFactor;
            transform.position = originalPosition + new Vector3(mouseDelta.x, mouseDelta.y, 0);
        }
    }
}
