using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    public float parallaxFactor = 0.1f; // speed

    private Vector3 startPosition;
    private Vector3 startMousePosition;

    void Start()
    {
        startPosition = transform.position;
        startMousePosition = Input.mousePosition;
    }

    void Update()
    {
        Vector3 mouseDelta = (Input.mousePosition - startMousePosition) * parallaxFactor;
        transform.position = startPosition + new Vector3(mouseDelta.x, mouseDelta.y, 0);
    }
}