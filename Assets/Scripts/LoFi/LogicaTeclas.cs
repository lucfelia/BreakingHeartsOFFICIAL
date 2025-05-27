using UnityEngine;

public class LogicaTeclas : MonoBehaviour
{
    public KeyCode keyToCheck;
    public LogicaContenedor contenedor;
    public float speed;
    public float height = 0f;
    public float margin = 0.3f;

    public bool inside = false;
    public bool missInside = false;

    private float vertical = -1f;

    private int counter = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(0, vertical).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Activar flags de detección según triggers
        inside = (counter == 2 || counter == 3);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) counter++;
        if (collision.CompareTag("MissArea")) missInside = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) counter--;
        if (collision.CompareTag("MissArea")) missInside = false;
    }
}
