using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoeyLevelSelect : MonoBehaviour
{
    public float alpha = 1.0f;

    public GameObject target = null;

    public List<GameObject> targets = new List<GameObject>();
    private int targetIndex = 0;

    private Vector2 targetPosition;
    private Vector2 currentPosition;
    bool onNode = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            targetIndex++;
            if (targetIndex >= targets.Count)
            {
                targetIndex = 0;
            }
            target = targets[targetIndex];
        }
        if (onNode && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Batalla_1"); // Cambia la escena
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            targetPosition = target.transform.position;
            currentPosition = transform.position;

            transform.position = Vector2.Lerp(currentPosition, targetPosition, alpha * Time.deltaTime);
            Vector3 pos = transform.position;
            pos.z = -1;
            transform.position = pos;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plataform")) // Verifica si colisiona con la plataforma
        {
            onNode = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Plataform")) // Verifica si colisiona con la plataforma
        {
            onNode = false;
        }
    }
}
