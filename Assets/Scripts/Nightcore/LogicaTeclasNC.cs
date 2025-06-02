using UnityEngine;

public class LogicaTeclasNC : MonoBehaviour
{
    public KeyCode keyToCheck;
    public LogicaContenedorNC contenedor;
    public float speed;
    public float height = 0f;
    public float margin = 0.3f;

    public bool inside = false;
    public bool missInside = false;

    public Vector2 direction = Vector2.down;

    private int counter = 0;

    void Start()
    {
        // Asignar automáticamente el contenedor si no está ya
        if (contenedor == null)
        {
            contenedor = FindObjectOfType<LogicaContenedorNC>();
        }
    }

    void Update()
    {
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
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
    public int GetCounter()
    {
        return counter;
    }
}