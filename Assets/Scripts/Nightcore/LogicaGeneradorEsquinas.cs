/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaGeneradorEsquinas : MonoBehaviour
{
    public GameObject[] teclasEsquinas;
    private float timeBetween;
    public float startTime;
    public int random;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetween <= 0)
        {
            random = UnityEngine.Random.Range(0, teclasEsquinas.Length);

            if (teclasEsquinas[random] == teclasEsquinas[0])
            {
                teclasEsquinas[0].transform.position = new Vector3(-9.4f, 5.5f);
            }
            else if (teclasEsquinas[random] == teclasEsquinas[1])
            {
                teclasEsquinas[1].transform.position = new Vector3(-9.4f, -5.5f);
            }
            else if (teclasEsquinas[random] == teclasEsquinas[2])
            {
                teclasEsquinas[2].transform.position = new Vector3(9.4f, -5.5f);
            }
            else if (teclasEsquinas[random] == teclasEsquinas[3])
            {
                teclasEsquinas[3].transform.position = new Vector3(9.4f, 5.5f);
            }

            Instantiate(teclasEsquinas[random]);

            timeBetween = startTime;
        }
        else
        {
            timeBetween -= Time.deltaTime;
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaGeneradorEsquinas : MonoBehaviour
{
    public GameObject[] teclasEsquinas;
    public Transform contenedorTransform; // Asigna aquí tu LogicaContenedorNC como padre

    private float timeBetween;
    public float startTime;
    public int random;

    void Update()
    {
        if (timeBetween <= 0)
        {
            random = Random.Range(0, teclasEsquinas.Length);

            Vector3 spawnPos = Vector3.zero;
            Vector2 direction = Vector2.zero;
            KeyCode key = KeyCode.None;

            // Configurar cada letra
            switch (random)
            {
                case 0: // Q
                    spawnPos = new Vector3(-9.4f, 5.5f);
                    direction = new Vector2(1, -1);
                    key = KeyCode.Q;
                    break;
                case 1: // Z
                    spawnPos = new Vector3(-9.4f, -5.5f);
                    direction = new Vector2(1, 1);
                    key = KeyCode.Z;
                    break;
                case 2: // M
                    spawnPos = new Vector3(9.4f, -5.5f);
                    direction = new Vector2(-1, 1);
                    key = KeyCode.M;
                    break;
                case 3: // P
                    spawnPos = new Vector3(9.4f, 5.5f);
                    direction = new Vector2(-1, -1);
                    key = KeyCode.P;
                    break;
            }

            // Instanciar la tecla
            GameObject obj = Instantiate(teclasEsquinas[random], spawnPos, Quaternion.identity, contenedorTransform);

            // Configurar los valores lógicos
            LogicaTeclasNC logica = obj.GetComponent<LogicaTeclasNC>();
            if (logica != null)
            {
                logica.direction = direction;
                logica.keyToCheck = key;
                logica.contenedor = contenedorTransform.GetComponent<LogicaContenedorNC>();
            }

            Debug.Log("Tecla instanciada: " + obj.name + " con tecla " + key);

            timeBetween = startTime;
        }
        else
        {
            timeBetween -= Time.deltaTime;
        }
    }
}
